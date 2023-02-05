using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float bulletTtl = 5;
    [SerializeField] GameObject bullet;
    [SerializeField] int damage = 1;
    [SerializeField] List<GameObject> enemyColliders;
    [SerializeField] GameObject[] gameObjects;

    void Update()
    {
        bulletTtl = bulletTtl - Time.deltaTime;
        if (bulletTtl <= 0)
        {
            Destroy(bullet);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //enemyColliders.Add(collision.gameObject.GetComponent<GameObject>());
            
            collision.gameObject.GetComponent<EnemyHealth>().RemoveHealth(damage);
        }
       
        Destroy(bullet);
        return;
    }
}