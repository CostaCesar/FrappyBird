using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float timer = 1.5f;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void ShowScore()
    {
        TMP_Text txt = GameObject.Find("ScoreNum").GetComponent<TMP_Text>();
        txt.text = score.ToString();
        score = 0;
    }
}
