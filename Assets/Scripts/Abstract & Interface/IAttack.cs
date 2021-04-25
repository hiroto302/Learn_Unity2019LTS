using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 攻撃処理を実装
// 攻撃用のインターフェイスを作成したが、攻撃の種類は複数あることが考えられる
// ダメージを受けた時の処理など、単一で考えられて共通したいものには利用することを念頭に置くといいかも
interface IAttack
{
    // 攻撃力
    int AttackPower {set; get;}
    void Attack(int attackPower);
}
