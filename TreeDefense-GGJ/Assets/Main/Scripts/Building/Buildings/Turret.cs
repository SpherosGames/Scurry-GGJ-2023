using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootingTimerDefault;
    [SerializeField] private int health;
    [SerializeField] private Building building;
    [SerializeField] private Nuts nut;
    
    private bool shootingTimerOn;
    private float shootingTimer;

    private void Awake()
    {
        building = GameObject.Find("Building").GetComponent<Building>();
        nut = GameObject.Find("/Nuts").GetComponent<Nuts>();

        shootingTimer = shootingTimerDefault;
    }

    private void Update()
    {
        if (shootingTimerOn)
        {
            shootingTimer -= Time.deltaTime;

            if (shootingTimer <= 0)
            {
                Shoot();
                shootingTimer = shootingTimerDefault;
            }
        }

        if (health <= 0)
        {
            building.DestroyBuilding(GetComponent<BuildPositionIndex>().GetBuildPosition());
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);
        nut.RemoveNuts(1);
    }

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            shootingTimerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            shootingTimerOn = false;
        }
    }
}