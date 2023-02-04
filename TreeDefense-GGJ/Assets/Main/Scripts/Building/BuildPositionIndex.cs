using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPositionIndex : MonoBehaviour
{
    [SerializeField] private int buildPosition;

    public void SetBuildPosition(int buildPositionIndex)
    {
        buildPosition = buildPositionIndex;
    }

    public int GetBuildPosition()
    {
        return buildPosition;
    }
}