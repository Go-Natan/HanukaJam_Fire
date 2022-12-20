using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
    [SerializeField] private bool flipSprite = true;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    
    private int _direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_direction * speed, _rb.velocity.y);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        var toOther = other.transform.position - transform.position;
        if (toOther.x > 0) {
            _direction = -1;
        } else {
            _direction = 1;
        }
        
        if (flipSprite) {
            _spriteRenderer.flipX = _direction != 1;
        }
    }
}
