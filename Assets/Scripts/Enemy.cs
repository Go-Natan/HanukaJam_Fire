using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float y_min;
    public int enemyLives = 10;
    [SerializeField] GameObject Splash;
    [SerializeField] private GameObject blink;
    private GameObject deathSound;
    
    public Rigidbody2D _rb;
    //movement speed in units per second
    public float movementSpeed = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        blink.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        y_min = -9;
        deathSound = GameObject.FindWithTag("Sound");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
        if (transform.position.y<y_min)
        {
            Score.life -= 1;
            Destroy(this.gameObject);
            UnityEngine.Debug.Log($"score:{Score.score},life:{Score.life}");
        }
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Drop")
        {
            Destroy(col.gameObject);
            Invoke("EnableBlink", 0f);
            Invoke("DisableBlink", 0.1f);
            enemyLives--;
            
            if (enemyLives <= 0)
            {
                Instantiate(Splash, transform.position, transform.rotation);
                Destroy(this.gameObject);
                deathSound.GetComponent<AudioSource>().Play();
                Score.score += 1;
            }
        }
    }

    private void EnableBlink()
    {
        blink.SetActive(true);
        
    }
    
    private void DisableBlink()
    {
        blink.SetActive(false);
        
    }

}
