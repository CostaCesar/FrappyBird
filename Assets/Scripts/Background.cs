using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Spawner spawner;

    private void Awake()
    {
        spawner = GameObject.Find("TowerSpawner").GetComponent<Spawner>();
    }

    void Update()
    {
        speed = spawner.GetCurrentSpeed() / 3;
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < -22.45f)
        {
            transform.position = new Vector3(22.44f, -2, 0);
        }
    }
}
