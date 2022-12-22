using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnInterval = 0.5f;
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
        Vector3 Offset = new Vector3(0.3f, 1.5f, 0);
        Instantiate(bulletPrefab, transform.position + Offset, transform.rotation);
    }
}
