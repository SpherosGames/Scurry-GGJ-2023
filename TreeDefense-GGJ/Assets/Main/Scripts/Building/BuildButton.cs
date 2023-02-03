using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    private Button button;
    private Building building;
    private GameObject spawnBuilding;

    private void Start()
    {
        button = GetComponent<Button>();

        building = GameObject.Find("Building").GetComponent<Building>();

        print("set onclick for : " + button);
        spawnBuilding = Resources.Load<GameObject>("Assets/Main/Prefabs/Buildings/Wall.prefab");
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => building.Build(spawnBuilding));
    }
}