using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ダメージを受けた時の処理を実装
interface IReceivedDamage
{
    void DamageHP(int damageAmount);
}
