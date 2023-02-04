using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer MineMesh;
    private bool isTriggered;
    [SerializeField] float mineCD = 3;
    [SerializeField] TMP_Text mineCDText;
    [SerializeField] CircleCollider2D Explosion;
    [SerializeField] ParticleSystem ps;
    [SerializeField] private float range;
    [SerializeField] private Building building;

    void Start()
    {
        animator = GetComponent<Animator>();
        mineCDText.enabled = false;
        Explosion.enabled = false;
        MineMesh = GetComponent<SpriteRenderer>();
        Explosion.radius = range;
        building = GameObject.Find("/Building").GetComponent<Building>();
    }

    void Update()
    {
        animator.SetBool("IsArmed", isTriggered);

        mineCDText.text = Mathf.Round(mineCD).ToString();
        if (isTriggered && mineCD > 0)
        {
            mineCDText.enabled = true;
            mineCD -= Time.deltaTime;
        }
        if (mineCD <= 0)
        {
            mineCDText.enabled = false;
            MineMesh.enabled = false ;
            MineExplosion();  
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isTriggered = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void MineExplosion()
    {
        ps.Play();
        Explosion.enabled = true;
        Invoke("Destroyed", 1f);
    }

    private void Destroyed()
    {
        building.DestroyBuilding(GetComponent<BuildPositionIndex>().GetBuildPosition());
    }
}