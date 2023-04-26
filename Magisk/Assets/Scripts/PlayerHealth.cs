using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float Health {
        set {
            health = value;
            if (health <= 0){
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1f;


    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }

    public void Defeated() {
        animator.SetBool("isAlive", false);
        rb.simulated = false;
    }

    
}
