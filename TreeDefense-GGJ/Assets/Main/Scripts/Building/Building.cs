using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject chooseBuildingPanel;
    [SerializeField] private Transform buildingParent;
    [SerializeField] private Transform buildCanvas;
    [SerializeField] private GameObject SelectPanel;
    [SerializeField] private GameObject[] buttons;

    private bool canBuild;
    private bool chooseBuildPanelActive;

    private Transform buildPosition;
    private GameObject buildingToSpawn;

    int buildPositionIndex;
    int removeBuildPositionIndex;

    public void Build(GameObject building)
    {
        buildingToSpawn = building;

        canBuild = true;
    }

    public void ChooseBuild()
    {
        buildPosition = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform;
        if (!chooseBuildPanelActive)
        {
            chooseBuildingPanel.SetActive(true);
            chooseBuildingPanel.transform.position = buildPosition.position;
            chooseBuildPanelActive = true;
        }
    }

    public void RemoveBuilding(int buildPositionIndexValue)
    {
        buildPositionIndex = buildPositionIndexValue;
        if (SelectPanel)
        {
            Destroy(SelectPanel);
            buttons[buildPositionIndex].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Can't find spawnedobject");
        }
    }

    private void Update()
    {
        if (canBuild)
        {
            chooseBuildPanelActive = false;
            SelectPanel = Instantiate(buildingToSpawn, buildPosition.transform.position, Quaternion.identity, buildingParent);
            canBuild = false;
        }
    }
}