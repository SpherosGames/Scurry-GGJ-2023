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

    private GameObject[] spawnedBuildings = new GameObject[3];

    private bool canBuild;
    private bool isChoosingBuilding;
    private bool chooseBuildPanelActive;

    private Transform buildPosition;
    private GameObject buildingToSpawn;

    int buildPositionIndexNum;
    //int removePositionIndexNum;

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
                Destroy(spawnedBuildings[removeIndex]);
                buttons[removeIndex].SetActive(true);
            }
            else
            {
                Debug.LogWarning("Can't find spawnedobject");
            }
        }
    }

    private void Update()
    {
        print(isChoosingBuilding);

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