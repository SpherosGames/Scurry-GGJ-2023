using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOffset : MonoBehaviour
{
    [SerializeField] private float yOffset;

    private void Start()
    {
        Vector2 currentPos = transform.position;
        currentPos.y += yOffset;
        transform.position = currentPos;
    }
}