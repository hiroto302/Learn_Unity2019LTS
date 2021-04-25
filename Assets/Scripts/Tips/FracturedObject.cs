using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedObject : MonoBehaviour
{
    void Start()
    {
        Rigidbody[] allRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(var brokenPiece in allRigidbodies)
        {
            brokenPiece.AddExplosionForce(300,transform.position, 1);
        }
    }
}
