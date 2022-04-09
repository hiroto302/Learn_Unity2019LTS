using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*群行動ルール
魚の群れを作成する際の基本ルールは、次のとおりです。

1. グループの平均的な位置に向かって移動する
つまり、グループ内のすべての位置の合計÷グループ内の魚の数です。
個々のメンバーの位置を加算して、グループ内のメンバーの数で除算することで、それぞれの位置とどのようにグループへ向かっているのかを特定するのに役立ちます。

2. グループの平均的な進行方向に合わせる
グループ内の個々の魚の進行方向を加算して、グループのサイズで除算することで、
進行方向の調整に使用する平均ベクトルを算出できます。

3. ほかのグループメンバーとの衝突を回避する
ほかのメンバーとの衝突を回避するため、個々の魚は周囲にいるほかの魚の位置と方向転換するタイミングを把握する必要があります。
個々の魚の新しい進行方向を計算するには、グループの中心へ向かって移動するベクトル、グループの進行方向に合わせるためのベクトル、
および周囲にいるメンバーから方向転換するためのベクトルを加算します。
*/
public class Flock : MonoBehaviour
{
    public FlockManager myManager;
    float speed;
    // 水泳の制限を確認するために使用するブール値
    bool turning = false;

    void Start()
    {
        // speed を割り当てる : Assign a random speed to each this prefab
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    void Update()
    {
        // Determine the bounding box of the manager cube
        Bounds b = new Bounds(myManager.transform.position, myManager.swimLimits * 2.0f);
        // If the fish is outside the bounds of the cube or about to hit something
        // then start turning around
        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;
        if (!b.Contains(transform.position))
        {
            turning = true;
            direction = myManager.transform.position - transform.position;
        }
        else if (Physics.Raycast(transform.position, this.transform.forward * 50.0f, out hit))
        {
            turning = true;
            // Debug.DrawRay(this.transform.position, this.transform.forward * 50.0f, Color.red);
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
        }
        else
        {
            turning = false;
        }

        // Test if we're turning
        if(turning)
        {
            // Turn towards the centre of the cube
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                myManager.rotationSpeed * Time.deltaTime);
        }
        else
        {
            // 10% chance of altering prefab speed
            if (Random.Range(0.0f, 100.0f) < 10.0f)
                speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);

            // 20& chance of applying the flocking rules
            if (Random.Range(0.0f, 100.0f) < 20.0f)
                ApplyRules();
        }

        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        // 現在の群行動内のすべての魚を保持する gos ホルダーを作成
        GameObject[] gos;;
        gos = myManager.allFish;

        // 平均中心
        Vector3 vcentre = Vector3.zero;
        // 平均回避ベクトル
        Vector3 vavoid = Vector3.zero;
        // グループのグローバル速度。これは、平均的なグループが移動する速度
        float gSpeed = 0.01f;
        // それぞれの魚にどれぐらい離れているか確認してから、グループにどれぐらい近いのか特定する
        float nDistance;
        // groupSize カウンターは、グループ内の魚の数をカウント。隣接距離にある群れの小さなサブセクションのように機能する
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            // 自身以外の魚を対象に下記の処理を実行する
            if(go != this.gameObject)
            {
                // 周囲の魚との距離を計算
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                // その距離が周囲の魚との距離以下の場合
                if (nDistance <= myManager.neighbourDistance)
                {
                    // closenet グループの魚と見なされ、その位置が vcenter に格納される中心に加算。合わせて、グループサイズも増加
                    vcentre += go.transform.position;
                    groupSize++;

                    // nDistance が非常に小さな値 (ここではハードコードされている 1.0) 未満かどうかテスト。
                    // これは、魚が衝突を回避する前にほかの魚とどれぐらい接近できるかを定義する。
                    // nDistance が 1.0f 未満の場合、平均ベクトルはそのベクトルにほかの魚から離れるためのベクトルを加えた値になる
                    // (つまり現在の位置からほかの魚を回避する位置を引いた値、反対方向のベクトル)
                    if( nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    // グローバル速度 (gSpeed) は、群れの中の特定の魚の速度の合計。
                    // 魚の Flock コードをアタッチしてある、その魚の速度を取得し gSpeed に加算
                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        // 魚が群れと一緒に動いていている場合
        if (groupSize > 0)
        {
            // Find the average centre of the group then add a vector to the target (goalPos)
            // 平均中心に 移動目標位置 ベクトルを加算
            vcentre = vcentre / groupSize + (myManager.goalPos - this.transform.position);
            // 平均スピード
            speed = gSpeed / groupSize;

            // 上記の情報から、魚が進む方向を決定(回転方向を求めるのに使用)
            Vector3 direction = (vcentre + vavoid) - transform.position;

            if( direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        myManager.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
