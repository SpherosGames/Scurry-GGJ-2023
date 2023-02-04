using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRemove : MonoBehaviour
{
    [SerializeField] private List<GameObject> removeButtons;

    private void Awake()
    {
        print("awake!");
        print(transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton").gameObject.name);
        removeButtons.Add(transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton").gameObject);
        removeButtons.Add(transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton (1)").gameObject);
        removeButtons.Add(transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton (2)").gameObject);
    }

    private void OnMouseEnter()
    {
        removeButtons[gameObject.GetComponent<BuildPositionIndex>().GetBuildPosition()].SetActive(true);
    }

    private void OnMouseExit()
    {
        removeButtons[gameObject.GetComponent<BuildPositionIndex>().GetBuildPosition()].SetActive(false);
    }
}