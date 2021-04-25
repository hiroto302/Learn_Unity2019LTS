using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionShere : MonoBehaviour
{
    [SerializeField] GameObject fracturedObject;

    void OnMouseDown()
    {
        Explosion();
    }
    void Explosion()
    {
        Instantiate(fracturedObject, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
