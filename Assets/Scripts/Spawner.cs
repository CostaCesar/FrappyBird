using UnityEngine;

public class Spawner : MonoBehaviour
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
    private GameObject objectToSpawn;
    [SerializeField]
    private float spacing;
    public float spawnInterval;
    private float counter = 0;
    public float timer = 0.0001f;

    // Update is called once per frame
    void Start()
    {
        counter = spawnInterval;
    }
    void Update()
    {
        if(counter <= 0)
        {
            Spawn();
        }
        counter -= Time.deltaTime;
    }

    public void Spawn()
    {
        float timerNow = Time.time;
        float height = Random.Range(lowerLimit, upperLimit);
        Vector3 spawnPos = new Vector3(transform.position.x, height + spacing, transform.position.z);
        Instantiate(objectToSpawn, spawnPos, transform.rotation)
            .GetComponent<Scrolling>().speed = baseSpeed + (incrementSpeed * (timerNow - timer) / 5);
        if(spacing > 0)
        {
            spawnPos.y = height - spacing;
            Instantiate(objectToSpawn, spawnPos, transform.rotation)
                .GetComponent<Scrolling>().speed = baseSpeed + (incrementSpeed * (timerNow - timer) / 5);
            spawnInterval -= 0.01f;
        }
        counter = spawnInterval;
    }

    public float GetCurrentSpeed()
    {
        float timerNow = Time.time;
        return baseSpeed + (incrementSpeed * (timerNow - timer) / 5);
    }   
}
