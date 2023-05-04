using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private float UpperLimit;
    [SerializeField]
    private float LowerLimit;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private GameObject towerObject;
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        if(counter <= 0)
        {
            float height = Random.Range(LowerLimit, UpperLimit);
            Vector3 towerPos = new Vector3(transform.position.x, height + 4.75f, transform.position.z);
            Instantiate(towerObject, towerPos, transform.rotation);
            towerPos.y = height - 4.75f;
            Instantiate(towerObject, towerPos, transform.rotation);
            counter = spawnInterval;
        }
        counter -= Time.deltaTime;
    }
}
