using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (col.collider.tag == "Shapes")
        {
            Destroy(other.gameObject);
        }
    }
}
