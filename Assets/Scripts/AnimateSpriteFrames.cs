using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpriteFrames : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    
    [SerializeField] private float frameRate = 1f;
    
    private int currentFrame = 0;
    
    private float timeSinceLastFrame = 0f;
    
    // Update is called once per frame
    void Update()
    {
        timeSinceLastFrame += Time.deltaTime;
        
        if (timeSinceLastFrame >= frameRate) {
            timeSinceLastFrame = 0f;
            currentFrame++;
            if (currentFrame >= frames.Length)
            {
                currentFrame = 0;
            }
            GetComponent<SpriteRenderer>().sprite = frames[currentFrame];
        }
        
    }
}
