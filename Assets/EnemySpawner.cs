using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 0.5f;
    public float timer = 0;
//    public Vector3 firstLocation;
    // Update is called once per frame
    void start()
    {
        enemyBubble();
  //      firstLocation = new Vector3(0,11,0);
    }
    void Update()
    {
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
        Vector3 placeToSpawn = new Vector3(Random.Range(-9, 9), 11, 0);

        Instantiate(enemyPrefab, placeToSpawn, transform.rotation);
    }
}
