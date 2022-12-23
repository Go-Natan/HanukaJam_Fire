using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] float destroyTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteObject", destroyTime);
    }

    
    void DeleteObject()
    {
       Destroy(gameObject); 
    }
}
