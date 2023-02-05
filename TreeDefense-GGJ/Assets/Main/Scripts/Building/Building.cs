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

    private bool purchaseValid;

    public void Build(GameObject building)
    {
        if (building.name == "Wall")
        {
            if (nuts.GetAmountOfNuts() > costs[0])
            {
                nuts.RemoveNuts(costs[0]);
                purchaseValid = true;
            }
            else
            {
                warningText.text = "Don't have enough money. Backspace to go back.";
                warningText.gameObject.SetActive(true);
                Invoke("RemoveWarning", 1f);
            }
        }
        else if (building.name == "Turret")
        {
            if (nuts.GetAmountOfNuts() > costs[1])
            {
                nuts.RemoveNuts(costs[1]);
                purchaseValid = true;
            }
            else
            {
                warningText.text = "Don't have enough money. Backspace to go back.";
                warningText.gameObject.SetActive(true);
                Invoke("RemoveWarning", 1f);
            }
        }
        else if (building.name == "Mine")
        {
            if (nuts.GetAmountOfNuts() > costs[2])
            {
                nuts.RemoveNuts(costs[2]);
                purchaseValid = true;
            }
            else
            {
                warningText.text = "Don't have enough money. Backspace to go back.";
                warningText.gameObject.SetActive(true);
                Invoke("RemoveWarning", 1f);
            }
        }
        else
        {
            Debug.LogWarning("Can't find placed building, no nuts removed from nuts pool");
        }

        if (purchaseValid)
        {
            if (isChoosingBuilding)
            {
                purchaseValid = false;
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
        }
        else
        {
            buttons[buildPositionIndexNum].gameObject.SetActive(true);
            isChoosingBuilding = false;
            chooseBuildPanelActive = false;
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

        if (chooseBuildPanelActive && Input.GetKeyDown(KeyCode.Backspace))
        {
            chooseBuildPanelActive = false;
            chooseBuildingPanel.SetActive(false);
            buttons[buildPositionIndexNum].SetActive(true);
            isChoosingBuilding = false;
        }
    }

    private void RemoveWarning()
    {
        warningText.gameObject.SetActive(false);
    }
}