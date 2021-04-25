using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物理挙動を無視した Play の移動用スクリプト
public class PlayerController_translate : MonoBehaviour
{
    Vector3 _inputVector;
    [SerializeField] float _moveSpeed = 2.0f;

    Vector3 directionToFace;

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        _inputVector = new Vector3(hor, 0, ver);

        Debug.DrawRay(transform.position, directionToFace, Color.blue);

        if(_inputVector.sqrMagnitude > 0.1)
        {
            // 移動したい方向の位置 : 現在位置から移動したい位置
            Vector3 directionToFacePosition = transform.position + _inputVector.normalized * 10.0f;
            // 移動方向 = destination - source
            directionToFace = directionToFacePosition - transform.position;
            // 上記での処理は、つまり以下の通りになる。 現在位置から、相対的にどこの方向を向きたいか.
            directionToFace = _inputVector.normalized * 10;
            // 回転
            Quaternion directionRotation = Quaternion.LookRotation(directionToFace);
            transform.rotation = Quaternion.Lerp(transform.rotation, directionRotation, Time.deltaTime * 2);
            // 移動
            transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
