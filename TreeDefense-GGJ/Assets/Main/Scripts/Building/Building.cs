using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject chooseBuildingPanel;
    [SerializeField] private Transform buildingParent;
    [SerializeField] private Transform buildCanvas;

    private bool canBuild;
    private bool chooseBuildPanelActive;

    private Transform buildPosition;
    private GameObject prefabToSpawn;
    private GameObject buildingToSpawn;
    private GameObject chooseBuildPanel;

    public void Build(GameObject building)
    {
        buildingToSpawn = building;
        print(building);
        canBuild = true;
    }

    public void ChooseBuild(GameObject objectToSpawn)
    {
        buildPosition = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform;
        prefabToSpawn = objectToSpawn;
        if (!chooseBuildPanelActive)
        {
            print("Spawn panel");
            chooseBuildingPanel = Instantiate(chooseBuildingPanel, buildPosition.transform.position, Quaternion.identity, buildCanvas);
            chooseBuildPanelActive = true;
        }
    }

    private void Update()
    {
        if (canBuild)
        {
            print("destroy panel : " + chooseBuildingPanel.name);
            chooseBuildPanelActive = false;
            Instantiate(buildingToSpawn, buildPosition.transform.position, Quaternion.identity, buildingParent);
            Destroy(chooseBuildPanel);
            canBuild = false;
        }
    }
}