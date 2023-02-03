using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    public void Start()
    {
     
    }
    void Update()
    {
       transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

    
    }
       
    
        
       
}
