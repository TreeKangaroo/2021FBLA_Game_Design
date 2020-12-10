using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectShapes : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x - 2;
        float y = transform.position.y - 1;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "DestroyZone")
        {
            Destroy(this.gameObject);
        }
    }
}
