using UnityEngine;

public class Scrolling: MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -15)
            GameObject.Destroy(gameObject);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
