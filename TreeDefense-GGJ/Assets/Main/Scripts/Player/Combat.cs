using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Combat : MonoBehaviour
{
    //[SerializeField]
   //public Transform Gun;
    //[SerializeField]
    //public Transform firePoint;
  //  [SerializeField]
    public GameObject bulletToFire;
    public float firePower;
    bool timerOn = true;
    bool canShoot = true;
    public float fireRate = 1;
    public TMP_Text Counter;
    public float ammoCount = 5;



    public void Start()
    {
         
    }
    void Update()
    {
//        Counter.text = ammoCount.ToString(); // UI spul, teveel werk om het in een andere script te doen.. het is een gamejam.
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount != 0)
            {
                GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(firePoint.up * firePower, ForceMode2D.Impulse);
                ammoCount--;
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