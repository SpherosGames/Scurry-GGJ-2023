using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    
    public float mineCD = 3;
    private SpriteRenderer MineMesh;
    public TMP_Text mineCDText;
    private bool isTriggered;
    public CircleCollider2D Explosion;
    public ParticleSystem ps;
    void Start()
    {
        
        mineCDText.enabled = false;
        Explosion.enabled = false;
        MineMesh = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
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
        Destroy(gameObject);
    }
}
