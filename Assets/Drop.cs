using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _rb;
    [SerializeField] float initialSpeed;
    [SerializeField] float bounceSpeed = 3f;
    public float angle_rad;
    public float direction;
    [SerializeField] float ballAngle = 50f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        angle_rad = Mathf.Deg2Rad * ballAngle;
        initialSpeed = 0.2f;
        direction = -1;
        Vector3 flightDirection =  new Vector3(direction*initialSpeed * Mathf.Cos(angle_rad), initialSpeed * Mathf.Sin(angle_rad), 0);
        _rb.AddForce(flightDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if(MathF.Abs(transform.position.x)>11)
        {
            Destroy(this.gameObject);
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     //Check for a match with the specified name on any GameObject that collides with your GameObject
    //     Debug.Log("Detected collision with slider");
    //     if (collision.gameObject.tag == "RightSlider" || collision.gameObject.tag == "LeftSlider")
    //     {
    //         //If the GameObject's name matches the one you suggest, output this message in the console
    //         direction *= -1; 
    //     }
    // }
    
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Identified collision with slider " + col.gameObject+this.gameObject.name, col.gameObject);
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        float positivityFactor = 0.2f; // makes it so the ball never bounces downwards off the slider.
        // Hit the left Racket?
        if (col.gameObject.name == "LeftSlider") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * bounceSpeed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RightSlider") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * bounceSpeed;
        }
    }
    
    
    float hitFactor(Vector2 dropPosition, Vector2 sliderPosition, float sliderHight) 
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (dropPosition.y - sliderPosition.y) / sliderHight;
    }

}
