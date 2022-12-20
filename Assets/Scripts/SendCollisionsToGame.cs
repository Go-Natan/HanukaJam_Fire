using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCollisionsToGame : MonoBehaviour
{
    private Game _game;
    
    // Start is called before the first frame update
    void Start()
    {
        _game = FindObjectOfType<Game>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj1 = gameObject;
        var obj2 = collision.gameObject;
        _game.OnCollision(obj1, obj2);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj1 = gameObject;
        var obj2 = collision.gameObject;
        _game.OnCollision(obj1, obj2);
    }
}
