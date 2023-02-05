using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnFromBuild : MonoBehaviour
{
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject outsideCam;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject eToReturn;
    [SerializeField] GameObject squirel;
    [SerializeField] BuildInteract build;
    [SerializeField] GameObject waveInfoText;

    private bool canUse;
    private bool doOnce = true;

    private void Update()
    {
        if (build.IsOutside())
        {
            if (doOnce)
            {
                doOnce = false;
                Invoke("CanUseTrue", 1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && build.IsOutside() && canUse)
        {
            waveInfoText.SetActive(false);
            doOnce = true;
            canUse = false;
            print("return from outside");
            build.SetIsOutside(false);
            cam2.SetActive(true);
            outsideCam.SetActive(false);
            eToReturn.SetActive(false);
            squirel.SetActive(true);
        }
    }

    private void CanUseTrue()
    {
        canUse = true;
        doOnce = true;
    }
}