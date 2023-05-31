using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    private Spawner spawner;
    private GameObject player;
    [SerializeField]
    private GameObject restartMenu;

    private void Start()
    {
        player = GameObject.Find("Player");
        spawner = GameObject.Find("TowerSpawner").GetComponent<Spawner>();
    }
    
    public void TriggerRestart(ExplosionSprite obj)
    {
        Time.timeScale = 0;
        StartCoroutine(obj.Explode());
        StartCoroutine(ShowMenu());
    }
    private IEnumerator RestartGame()
    {
        restartMenu.SetActive(false);
        
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Killer");
        foreach(GameObject x in toDestroy)
            Destroy(x);
        player.transform.position = new Vector3(-6, 0, -1);
        
        spawner.timer = Time.time;
        spawner.spawnInterval = 3;
        yield return new WaitForSecondsRealtime(2);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        Time.timeScale = 1;
    }

    private void RestartWrapper()
    {
        StartCoroutine(RestartGame());
    }

    private IEnumerator ShowMenu()
    {
        yield return new WaitForSecondsRealtime(3);
        restartMenu.SetActive(true);
        GameObject.Find("ScoreManager").GetComponent<Score>().ShowScore();
        restartMenu.transform.Find("RestartBtn").GetComponent<Button>()
            .onClick.AddListener(RestartWrapper);
    }
}

