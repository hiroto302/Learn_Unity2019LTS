using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy と戦う勇者
public class Player_a : MonoBehaviour, IReceivedDamage, IAttack
{
    public int hp = 10;
    public int AttackPower { set; get;}

    void Update()
    {
        Attack(3);
    }

    // 攻撃処理
    public void Attack(int attackPower)
    {
        if(Input.GetMouseButton(0))
        {
            // Rayをマウスで押した所に飛ばす
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(rayOrigin.origin, rayOrigin.direction, Color.green);
            // Raycatによる情報を格納
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin, out hitInfo, 100))
            {
                // // Interface で機能を管理することで、ダメージを与えることができる敵が多様化しても、対応することができる
                IReceivedDamage obj = hitInfo.collider.GetComponent<IReceivedDamage>();
                // ダメージを与えることが出来る対象の時
                if(obj != null && !hitInfo.collider.CompareTag("Player"))
                {
                    // 相手のHPを減らす
                    obj.DamageHP(attackPower);
                }
            }
        }
    }

    // ダメージを受けた時の処理
    public void DamageHP(int damageAmount)
    {
        Debug.Log(damageAmount + ": ダメージを受けた");
        hp -= damageAmount;
        if(hp <= 0)
        {
            Die();
        }
    }

    // 死んだ時の処理
    void Die()
    {
        Destroy(this.gameObject);
    }
}
