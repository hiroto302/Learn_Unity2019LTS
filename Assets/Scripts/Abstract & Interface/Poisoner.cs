using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisoner : Enemy, IReceivedDamage, IAttack
{
    public int AttackPower { set; get; }
    // 敵が攻撃する対象
    public Player_a player;

    public Poisoner()
    {
        hp = 10;
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<Player_a>();
        Attack(3);
    }
    public void Attack(int attackPower)
    {
        // 毒攻撃 : １秒おきに attackPower ダメージ与える
        StartCoroutine(poisonAttack(attackPower));
    }

    IEnumerator poisonAttack(int attackPower)
    {
        while(attackPower > 0)
        {
            player.DamageHP(1);
            attackPower--;
            yield return new WaitForSeconds(1);
        }
    }
    // ダメージを受けた時の処理
    public void DamageHP(int damageAmount)
    {
        Debug.Log(damageAmount + ": ダメージを与えた");
        hp -= damageAmount;
        if(hp <= 0)
        {
            Die();
        }
    }
    // 死んだ時の処理
    public override void Die()
    {
        base.Die();
        Debug.Log("倒された！！");
    }
}
