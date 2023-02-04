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
    SpriteRenderer[] enemySprites;
    [SerializeField] BuildInteract build;
    [SerializeField] BuildInteract windowBuild;

    private bool canUse;
    private bool canUse2;
    private bool doOnce = true;
    private bool doOnce2 = true;

    private void Update()
    {
        print("CanUse : " + canUse2);
        print("Do Once : " + doOnce2);

        if (build.IsOutside())
        {
            if (doOnce)
            {
                doOnce = false;
                Invoke("CanUseTrue", 1f);
            }
        }

        if (windowBuild.IsOutside())
        {
            if (doOnce2)
            {
                doOnce2 = false;
                Invoke("CanUseTrue2", 1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && build.IsOutside() && canUse)
        {
            doOnce = true;
            canUse = false;
            print("return from outside");
            build.SetIsOutside(false);
            cam2.SetActive(true);
            outsideCam.SetActive(false);
            eToReturn.SetActive(false);
            squirel.SetActive(true);

            enemySprites = enemies.GetComponentsInChildren<SpriteRenderer>();

            foreach (var enemy in enemySprites)
            {
                enemy.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && windowBuild.IsOutside() && canUse2)
        {
            doOnce2 = true;
            canUse2 = false;
            print("return from outside");
            build.SetIsOutside(false);
            cam2.SetActive(true);
            outsideCam.SetActive(false);
            eToReturn.SetActive(false);
            squirel.SetActive(true);

            enemySprites = enemies.GetComponentsInChildren<SpriteRenderer>();

            foreach (var enemy in enemySprites)
            {
                enemy.enabled = true;
            }
        }
    }

    private void CanUseTrue()
    {
        canUse = true;
        doOnce = true;
    }

    private void CanUseTrue2()
    {
        canUse2 = true;
        doOnce2 = true;
    }
}