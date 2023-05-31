using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Spawner spawner;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        spawner = GameObject.Find("TowerSpawner").GetComponent<Spawner>();
    }
    public IEnumerator RestartGame(ExplosionSprite obj)
    {
        yield return obj.Explode();
        
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
}

