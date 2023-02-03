using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BulletScript : MonoBehaviour
{
    float bulletTtl = 5;
    [SerializeField]
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTtl = bulletTtl - Time.deltaTime;
        if (bulletTtl <= 0)
        {
            //GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(bullet);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        Destroy(bullet);
    }
}
