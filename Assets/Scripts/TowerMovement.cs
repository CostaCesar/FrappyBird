using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Sprite[] sprites;

    private void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -12)
            GameObject.Destroy(gameObject);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
