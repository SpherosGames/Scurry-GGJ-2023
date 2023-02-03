using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Nuts : MonoBehaviour
{
    [SerializeField] private int nutCount;
    [SerializeField] private TMP_Text nutCountText;

    private void Update()
    {
        nutCountText.text = "Nuts : " + nutCount.ToString();
    }
}