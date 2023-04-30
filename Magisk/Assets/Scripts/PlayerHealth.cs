using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public HealthBar healthBar;

    public float Health {
        set {
            health = value;
            healthBar.SetHealth(health);
            if (health <= 0){
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 250f;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
        healthBar.SetMaxHealth(health);
    }

    public void Defeated() {
        animator.SetBool("isAlive", false);
        rb.simulated = false;
    }

    
}
