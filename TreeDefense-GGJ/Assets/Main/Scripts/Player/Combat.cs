using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Combat : MonoBehaviour
{
    [SerializeField]
   public Transform Gun;
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public GameObject bulletToFire;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    public float firePower;
    bool timerOn = true;
    bool canShoot = true;
    public float fireRate = 1;
    public Vector2 mousePos;
    public Camera cam;
    

    public void Start()
    {
         
    }
    void Update()
    {
        
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(firePoint.up * firePower, ForceMode2D.Impulse);
                canShoot = false;
                timerOn = true;
            }
        }

        if (timerOn)
        {
            fireRate -= Time.deltaTime; // Shoottimer gaat elke keer 1 naar beneden
            if (fireRate <= 0)
            {
                fireRate = 1;
                canShoot = true;
                timerOn = false;
            }
        }
    }
 

   
 }