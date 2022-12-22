using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    public float movementSpeed = 5f;

    public Rigidbody2D _rb;
    public SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Vertical axis
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.W)) // UpArrow	, DownArrow
        {
            verticalInput  = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput  = -1;
        }
        //update the position
        transform.position = transform.position + new Vector3(0, verticalInput * movementSpeed * Time.deltaTime, 0);

        // _rb.velocity = new Vector2(_direction * speed, _rb.velocity.y);
        
    }
}
