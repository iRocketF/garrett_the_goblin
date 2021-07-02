using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hitpoints;
    public float invulnerabilityTimer;
    private float timer;
    public bool tookDamage;
    public bool isInvulnerable;
    public bool isPlayerAlive;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        isPlayerAlive = true;
        tookDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tookDamage & timer < invulnerabilityTimer)
        {
            isInvulnerable = true;
            timer += Time.deltaTime;

            if (timer > invulnerabilityTimer)
            {
                timer = 0f;
                tookDamage = false;
                isInvulnerable = false;
            }      
        }

        if (hitpoints <= 0f && isPlayerAlive)
        {
            isPlayerAlive = false;
            manager.LoseGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile") && !isInvulnerable)
        {
            hitpoints--;
            tookDamage = true;
        }
    }
}
