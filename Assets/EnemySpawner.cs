using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] float spawnInterval;
    public float timer;
//    public Vector3 firstLocation;
    // Update is called once per frame
    void Start()
    {
        timer = 0;
        enemyBubble();
  //      firstLocation = new Vector3(0,11,0);
    }
    void Update()
    {
        //UnityEngine.Debug.Log($"Enemy Spawner timer:{timer}");
        if (timer < spawnInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            enemyBubble();
            timer = 0;
        }

    }
    void enemyBubble()
    {
        Vector3 placeToSpawn = new Vector3(Random.Range(-9, 9), Random.Range(6,12), 0);

        Instantiate(enemyPrefab, placeToSpawn, transform.rotation);
    }
}
