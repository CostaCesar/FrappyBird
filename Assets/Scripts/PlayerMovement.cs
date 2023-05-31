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
        ExplosionSprite obj = Instantiate(explosionSprite, transform.position, transform.rotation)
            .GetComponent<ExplosionSprite>();
        GetComponent<Reset>().TriggerRestart(obj);
    }
}
