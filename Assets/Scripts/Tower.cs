using UnityEngine;

public class Tower: MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private Score scoreManager;
    private GameObject player;

    private void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        scoreManager = GameObject.Find("ScoreManager").GetComponent<Score>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(player.transform.position.x > transform.position.x && scoreManager.timer < 0)
        {
            scoreManager.timer = 1.5f;
            scoreManager.score++;
        }
    }
}
