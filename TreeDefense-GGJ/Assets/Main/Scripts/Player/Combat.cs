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
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gun.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(Gun.up * firePower, ForceMode2D.Impulse);
            

        }
    }
}
