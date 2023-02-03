using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField]
   public Transform Gun;
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public GameObject bulletToFire;
    public float firePower;
    bool timerOn = true;
    bool canShoot = true;
    public float fireRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gun.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
