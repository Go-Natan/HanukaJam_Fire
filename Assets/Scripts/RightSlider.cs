using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSlider : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    public float movementSpeed = 5f;

    private Rigidbody2D _rb;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Vertical axis
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput  = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            verticalInput  = -1;
        }
        //update the position
        transform.position = transform.position + new Vector3(0, verticalInput * movementSpeed * Time.deltaTime, 0);

        // _rb.velocity = new Vector2(_direction * speed, _rb.velocity.y);
        
    }
}
