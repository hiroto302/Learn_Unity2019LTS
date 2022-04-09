using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*群行動の効果とルール
FlockManager の次の値は、魚の動作に対して設定する必要があります。

neighborDistance (周囲の魚との距離) を上げると、群れがなくなります。
neighborDistance を元に戻しても、すべての魚が群れになるわけではありません。
これには回転速度も影響します。回転速度を上げると、いくつかの新しい動作が見られるようになります。

コードに戻っていくつかの変更を加えます。群行動の効果を得るには、flocking.cs コードの update メソッドで新しい ApplyRules() メソッドを記述します。


*/
public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numFish = 5;
    public GameObject[] allFish;
    public Vector3 swimLimits = new Vector3 (5.0f, 5.0f, 5.0f);
    public Vector3 goalPos;

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    void Start()
    {
        // Allocate the allFish array
        allFish = new GameObject[numFish];
        // 魚Prefab を生成
        for (int i = 0; i < numFish; ++i)
        {
            // 生成位置
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.x, swimLimits.x));
            // 生成
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            // 生成した魚の管理者を、この Managerクラスに指定
            allFish[i].GetComponent<Flock>().myManager = this;
        }

        // Target for the prefabs to head for
        goalPos = this.transform.position;
    }

    void Update()
    {
        // 魚の向かうべきターゲットをランダムな確率で更新
        if (Random.Range(0f, 100.0f) < 10.0f)
        {
            // goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
            //                                                 Random.Range(-swimLimits.x, swimLimits.x),
            //                                                 Random.Range(-swimLimits.x, swimLimits.x));
        }
    }
}
