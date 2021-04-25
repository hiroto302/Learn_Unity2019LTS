using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物理挙動を無視した Play の移動用スクリプト
public class PlayerController_translate : MonoBehaviour
{
    Vector3 _inputVector;
    [SerializeField] float _moveSpeed = 2.0f;

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        _inputVector = new Vector3(hor, 0, ver);
        if(_inputVector.sqrMagnitude > 0.1)
        {
            // 現在位置に移動したい方向を足す
            Vector3 directionToFace = transform.position + _inputVector.normalized * 10.0f;
            Debug.Log(directionToFace);
            // y を 0
            directionToFace = new Vector3(directionToFace.x, 0, directionToFace.z);
            Debug.DrawRay(transform.position, directionToFace, Color.blue);
            Quaternion directionRotation = Quaternion.LookRotation(directionToFace);
            transform.rotation = Quaternion.Lerp(transform.rotation, directionRotation, Time.deltaTime * 2);
            // transform.rotation = directionRotation;
            // transform.LookAt(transform.position + _inputVector.normalized);
            transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
