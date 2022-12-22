using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] float spawnInterval = 0.1f;
    public float timer = 0;
    // Update is called once per frame
    void Start()
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
