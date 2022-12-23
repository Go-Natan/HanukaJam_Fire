using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float y_min;

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
            Destroy(this.gameObject);
            Score.life -= 1;
        }
        UnityEngine.Debug.Log($"score:{Score.score},life:{Score.life}");
    }
    void OnCollisionEnter2D(Collision2D col) {
        //UnityEngine.Debug.Log("Identified collision with slider " + col.gameObject, col.gameObject);
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        if (col.gameObject.tag == "Drop")
        {
            Score.score += 1;
            Destroy(col.gameObject);
           // Destroy(col.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }

}
