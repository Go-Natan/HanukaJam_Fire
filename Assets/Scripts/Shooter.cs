using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnInterval = 3;
    public float timer = 0;
    // Update is called once per frame
    void start()
    {
        spawnBubble();
    }
    void Update()
    {
        if (timer <spawnInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnBubble();
            timer = 0;
        }
        
    }
    void spawnBubble()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
