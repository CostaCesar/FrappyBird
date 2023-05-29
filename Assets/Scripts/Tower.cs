using UnityEngine;

public class Tower: MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
