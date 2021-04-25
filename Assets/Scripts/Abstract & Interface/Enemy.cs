using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy の抽象クラス
public abstract class Enemy : MonoBehaviour
{
    public int hp;
    public string type;

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
