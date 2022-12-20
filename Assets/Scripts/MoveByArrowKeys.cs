using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByArrowKeys : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [SerializeField] private bool useArrows = true;
    [SerializeField] private bool useWASD = true;
    
    [SerializeField] private bool rotateSprite = true;
    [SerializeField] private float rotationOffset;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2Int direction = Vector2Int.zero;
        if (useArrows) {
            if (Input.GetKey(KeyCode.UpArrow)) { direction += Vector2Int.up; }
            if (Input.GetKey(KeyCode.DownArrow)) { direction += Vector2Int.down; }
            if (Input.GetKey(KeyCode.LeftArrow)) { direction += Vector2Int.left; }
            if (Input.GetKey(KeyCode.RightArrow)) { direction += Vector2Int.right; }
        }
        if (useWASD) {
            if (Input.GetKey(KeyCode.W)) { direction += Vector2Int.up; }
            if (Input.GetKey(KeyCode.S)) { direction += Vector2Int.down; }
            if (Input.GetKey(KeyCode.A)) { direction += Vector2Int.left; }
            if (Input.GetKey(KeyCode.D)) { direction += Vector2Int.right; }
        }

        var direction3D = new Vector3(direction.x, direction.y, 0f);

        _rb.velocity = direction3D * speed;
        
        if (rotateSprite) {
            if (direction != Vector2Int.zero) {
                var rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _spriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, rotation + rotationOffset);
            }
        }
    }
}
