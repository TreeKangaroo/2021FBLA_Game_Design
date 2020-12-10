using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEffect : MonoBehaviour
{
    public Transform[] Points;
    public GameObject[] Shapes;
    public float SpawnInterval;
    private float Timer;

    private void Start()
    {
        Time.timeScale = 1;
        Timer = 0;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnInterval)
        {
            Debug.Log("effect");
            for (int i = 0; Points.Length > i; i++)
            {
                int RandShape = Random.Range(0, Shapes.Length - 1);
                Instantiate(Shapes[RandShape], new Vector3(Points[i].position.x, Points[i].position.y), Quaternion.identity);
            }
            Timer = 0;
        }
    }
}
