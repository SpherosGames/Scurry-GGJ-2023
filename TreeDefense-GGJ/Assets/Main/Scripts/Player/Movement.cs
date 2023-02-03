using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;

    public void Start()
    {
     
    }
    void Update()
    {
       SpeedMovement();
       
       if(Input.GetButton("Fire3"))
       {
           transform.Translate(Vector2.right * moveSpeed * sprintSpeed* Time.deltaTime * Input.GetAxis("Horizontal"));
       }
    
    }

    void SpeedMovement()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

}
