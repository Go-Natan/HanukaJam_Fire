using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D _rb;
    //movement speed in units per second
    public float movementSpeed = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
    }
}
