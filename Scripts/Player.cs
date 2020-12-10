using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (col.gameObject.tag == "Item")
        {
            LevelUI.Items += 1;
            FindObjectOfType<AudioManager>().Play("Token");
            Destroy(other);           
        }

        if (col.gameObject.tag == "Border")
        {
            FindObjectOfType<AudioManager>().Play("Border");
        }
    }
}
