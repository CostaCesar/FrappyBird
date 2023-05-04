using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -12)
            GameObject.Destroy(gameObject);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
