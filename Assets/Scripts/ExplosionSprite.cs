using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite[] frames;
    [SerializeField]
    private float framesPerSecond;
    private SoundEffects sound;

    public IEnumerator Explode()
    {
        sound = GameObject.Find("Sounds").GetComponent<SoundEffects>();
        sound.PlayExplosion();
        for(int i = 0; i < frames.Length; i++)
        {
            GetComponent<SpriteRenderer>().sprite = frames[i];
            yield return new WaitForSecondsRealtime(Random.Range(0.2f, 0.33f));
        }
        GetComponent<SpriteRenderer>().sprite = null;
        Destroy(gameObject);
    }
}
