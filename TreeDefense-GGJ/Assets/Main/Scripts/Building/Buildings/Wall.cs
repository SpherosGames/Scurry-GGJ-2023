using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Building building;

    private void Awake()
    {
        building = GameObject.Find("Building").GetComponent<Building>();
    }

    public void RemoveHealth(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            building.DestroyBuilding(GetComponent<BuildPositionIndex>().GetBuildPosition());
            print("Wall has been destroyed");
        }
    }

    public int GetHealth()
    {
        return health;
    }
}