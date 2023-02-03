using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRemove : MonoBehaviour
{
    [SerializeField] private GameObject[] removeButtons;

    private void Awake()
    {
        print("awake!");
        removeButtons[0] = transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton").gameObject;
        removeButtons[1] = transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton (1)").gameObject;
        removeButtons[2] = transform.Find("/BuildCanvas").Find("RemoveButtons").Find("RemoveButton (2)").gameObject;
    }

    private void OnMouseEnter()
    {
        removeButtons[0].SetActive(true);
    }

    private void OnMouseExit()
    {
        removeButtons[0].SetActive(false);
    }
}