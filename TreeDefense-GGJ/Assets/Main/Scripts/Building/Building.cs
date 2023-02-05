using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject chooseBuildingPanel;
    [SerializeField] private Transform buildingParent;
    [SerializeField] private Transform buildCanvas;
    [SerializeField] private GameObject spawnedBuilding;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private TMP_Text warningText;
    [SerializeField] private Nuts nuts;
    [SerializeField] private int[] costs;
    [SerializeField] private int[] returnCosts;

    private GameObject[] spawnedBuildings = new GameObject[4];

    private bool canBuild;
    private bool isChoosingBuilding;
    private bool chooseBuildPanelActive;

    private Transform buildPosition;
    private GameObject buildingToSpawn;

    int buildPositionIndexNum;

    public void Build(GameObject building)
    {
        if (isChoosingBuilding)
        {
            buildingToSpawn = building;
            building.GetComponent<BuildPositionIndex>().SetBuildPosition(buildPositionIndexNum);
            canBuild = true;
            isChoosingBuilding = false;
        }
        else
        {
            warningText.text = "Can't Build Here";
            warningText.gameObject.SetActive(true);
            Invoke("RemoveWarning", 1f);
        }

        if (building.name == "Wall")
        {
            nuts.RemoveNuts(costs[0]);
        }
        else if (building.name == "Turret")
        {
            nuts.RemoveNuts(costs[1]);
        }
        else if (building.name == "Mine")
        {
            nuts.RemoveNuts(costs[2]);
        }
        else
        {
            Debug.LogWarning("Can't find placed building, no nuts removed from nuts pool");
        }
    }

    public void ChooseBuild(int buildPositionIndex)
    {
        if (isChoosingBuilding)
        {
            warningText.text = "Can't Build Here";
            warningText.gameObject.SetActive(true);
            Invoke("RemoveWarning", 1f);
        }
        else
        {
            buttons[buildPositionIndex].gameObject.SetActive(false);
            isChoosingBuilding = true;
            buildPositionIndexNum = buildPositionIndex;
            buildPosition = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform;
            if (!chooseBuildPanelActive)
            {
                chooseBuildingPanel.SetActive(true);
                chooseBuildingPanel.transform.position = buildPosition.position;
                chooseBuildPanelActive = true;
            }
        }
    }

    public void RemoveBuilding(int removeIndex)
    {
        if (isChoosingBuilding)
        {
            warningText.text = "Can't Remove Now";
            warningText.gameObject.SetActive(true);
            Invoke("RemoveWarning", 1f);
        }
        else
        {
            if (spawnedBuilding)
            {
                if (spawnedBuilding.name == "Wall(Clone)")
                {
                    nuts.RemoveNuts(-returnCosts[0]);
                }
                else if (spawnedBuilding.name == "Turret(Clone)")
                {
                    nuts.RemoveNuts(-returnCosts[1]);
                }
                else if (spawnedBuilding.name == "Mine(Clone)")
                {
                    nuts.RemoveNuts(-returnCosts[2]);
                }
                else
                {
                    Debug.LogWarning("Can't find destroyed building, no nuts removed from nuts pool");
                }

                Destroy(spawnedBuildings[removeIndex]);
                buttons[removeIndex].SetActive(true);
            }
            else
            {
                Debug.LogWarning("Can't find spawnedobject");
            }
        }
    }

    public void DestroyBuilding(int removeIndex)
    {
        Destroy(spawnedBuildings[removeIndex]);
        buttons[removeIndex].SetActive(true);
    }

    private void Update()
    {
        if (canBuild)
        {
            chooseBuildPanelActive = false;
            spawnedBuilding = Instantiate(buildingToSpawn, buildPosition.transform.position, Quaternion.identity, buildingParent);
            spawnedBuildings[buildPositionIndexNum] = spawnedBuilding;
            canBuild = false;
        }
    }

    private void RemoveWarning()
    {
        warningText.gameObject.SetActive(false);
    }
}