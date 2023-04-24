using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    public float Health {
        set {
            if (value < health) {
                animator.SetTrigger("hit");
            }

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
        animator.SetBool("isAlive", true);
    }

    public void Defeated() {
        animator.SetBool("isAlive", false);
    }

    public void RemoveObject() {
        Destroy(gameObject);
    }

}
