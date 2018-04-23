using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHealth : MonoBehaviour {
    public int maxHealth = 3;
    public float invulnDuration = 0.5f;
    public float inWaterKnockback = 5.0f;
    public float inAirKnockback = 1.0f;

    private int health;
    private float invulnTimer = 0.0f;
    private bool isAlive = true;

    private Rigidbody2D rbody;
    private FishMovement movement;
    private Animator animator;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        rbody = GetComponent<Rigidbody2D>();
        movement = GetComponent<FishMovement>();
        animator = GetComponent<Animator>();
	}

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer < 0.0f) {
            movement.enabled = true;
            animator.SetBool("isKnocked", false);
        }
    }

    public void TakeDamage(int amount)
    {
        if (invulnTimer > 0.0f)
            return;

        float knockbackRatio = (movement.inWater > 0) ? inWaterKnockback : inAirKnockback;
        
        // Start invulnerability, but can't move
        invulnTimer = invulnDuration;
        movement.enabled = false;
        animator.SetBool("isKnocked", true);
        rbody.velocity = - knockbackRatio * rbody.velocity;

        health -= amount;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        isAlive = false;
        invulnTimer = Mathf.Infinity;
        movement.enabled = false;
        animator.SetBool("isKnocked", false);
        animator.SetTrigger("die");
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
