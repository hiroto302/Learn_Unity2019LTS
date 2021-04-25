using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Player : MonoBehaviour
{
    [SerializeField] Transform _target;

    void Update()
    {
        Vector3 directionToFace = _target.position - transform.position;
        Debug.DrawRay(transform.position, directionToFace, Color.black);
        // 常時エイム
        // transform.rotation = Quaternion.LookRotation(directionToFace);
        // ゆっくりエイム
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
