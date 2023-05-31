using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float timer;
    private SoundEffects sound;

    private void Start()
    {
        sound = GameObject.Find("Sounds").GetComponent<SoundEffects>();
    }

    public void ResetTimer()
    {
        timer = 2.25f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void AddScore()
    {
        ResetTimer();
        score++;
        sound.PlayScore();
    }

    public void ShowScore()
    {
        TMP_Text txt = GameObject.Find("ScoreNum").GetComponent<TMP_Text>();
        txt.text = score.ToString();
        
        score = 0;
        ResetTimer();
    }
}
