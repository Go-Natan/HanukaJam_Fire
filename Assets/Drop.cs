using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _rb;
    public float speed;
    public float angle_rad;
    public float direction;
    public float ballAngle = 20;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        angle_rad = Mathf.Deg2Rad * ballAngle;
        speed = 0.1f;
        direction = -1;
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        Vector3 flightDirection =  new Vector3(direction*speed * Mathf.Cos(angle_rad), speed * Mathf.Sin(angle_rad), 0);
        _rb.AddForce(flightDirection);
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     // transform.position = transform.position + new Vector3(direction*speed * Mathf.Cos(angle_rad), speed * Mathf.Sin(angle_rad), 0);
    //     Vector3 flightDirection =  new Vector3(direction*speed * Mathf.Cos(angle_rad), speed * Mathf.Sin(angle_rad), 0);
    //     _rb.AddForce(flightDirection);
    //
    //     
    // }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     //Check for a match with the specified name on any GameObject that collides with your GameObject
    //     Debug.Log("Detected collision with slider");
    //     if (col.gameObject.tag == "RightSlider" || col.gameObject.tag == "LeftSlider")
    //     {
    //         //If the GameObject's name matches the one you suggest, output this message in the console
    //         direction *= -1; 
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D col)
    {
        float y = hitFactor(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }


    //https://noobtuts.com/unity/2d-pong-game
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    
    
}
