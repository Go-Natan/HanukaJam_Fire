using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float y_min;
    public int enemyLives = 10;

    public Rigidbody2D _rb;
    //movement speed in units per second
    public float movementSpeed = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        y_min = -9;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
        if (transform.position.y<y_min)
        {
            Score.life -= 1;
            Destroy(this.gameObject);
            UnityEngine.Debug.Log($"score:{Score.score},life:{Score.life}");
        }
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Drop")
        {
            Destroy(col.gameObject);
            enemyLives--;
            if (enemyLives <= 0)
            {
                Destroy(this.gameObject);
                Score.score += 1;
            }
        }
    }

}
