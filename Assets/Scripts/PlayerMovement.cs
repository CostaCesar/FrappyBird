using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionSprite;
    [SerializeField]
    private float force;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Fire1") == true || Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Time.timeScale = 0;
        ExplosionSprite obj = Instantiate(explosionSprite, transform.position, transform.rotation)
            .GetComponent<ExplosionSprite>();
        StartCoroutine(Reset(obj));
    }

    private IEnumerator Reset(ExplosionSprite obj)
    {
        yield return obj.Explode();
        
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Killer");
        foreach(GameObject x in toDestroy)
            Destroy(x);

        transform.position = new Vector3(-6, 0, 0);
        
        TowerSpawner spawner = GameObject.Find("Towers").GetComponent<TowerSpawner>();
        spawner.timer = Time.time;
        spawner.spawnInterval = 3;

        yield return new WaitForSecondsRealtime(2);
        this.rb.velocity = Vector3.zero;
        Time.timeScale = 1;
    }
}
