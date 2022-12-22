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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        angle_rad = Mathf.Deg2Rad * 45;
        speed = 0.05f;
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(direction*speed * Mathf.Cos(angle_rad), speed * Mathf.Sin(angle_rad), 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Slider")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            direction *= -1; 
        }
    }
}
