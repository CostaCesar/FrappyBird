using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float lowerLimit;
    [SerializeField]
    private float baseSpeed;
    [SerializeField]
    private float incrementSpeed;
    [SerializeField]
    private GameObject towerObject;
    public float spawnInterval;
    private float counter = 0;
    public float timer = 0.0001f;

    // Update is called once per frame
    void Update()
    {
        float timerNow = Time.time;
        if(counter <= 0)
        {
            float height = Random.Range(lowerLimit, upperLimit);
            Vector3 towerPos = new Vector3(transform.position.x, height + 4.75f, transform.position.z);
            Instantiate(towerObject, towerPos, transform.rotation)
                .GetComponent<TowerMovement>().speed = baseSpeed + (incrementSpeed * (timerNow - timer) / 5);
            towerPos.y = height - 4.75f;
            Instantiate(towerObject, towerPos, transform.rotation)
                .GetComponent<TowerMovement>().speed = baseSpeed + (incrementSpeed * (timerNow - timer) / 5);
            counter = spawnInterval;
            spawnInterval -= 0.01f;
        }
        counter -= Time.deltaTime;
    }
}
