using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    public float damage = 1f;

    public DetectionZone detectionZone;

    float movementSpeed = 1f;

    Rigidbody2D rb;

    void FixedUpdate() {
        if(detectionZone.detectedObj.Count > 0) {
            Collider2D target = detectionZone.detectedObj[0];
            Vector2 direction = target.transform.position - transform.position;
            animator.SetBool("isMoving", true);
            direction.Normalize();
            rb.velocity = direction * movementSpeed;
        } else {
            rb.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }
    }

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
        rb = GetComponent<Rigidbody2D>();
    }

    public void Defeated() {
        animator.SetBool("isAlive", false);
    }

    public void RemoveObject() {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) {
      float distance = Vector3.Distance(transform.position, other.gameObject.transform.position);
      print(distance);
      if (distance <= 0.7f) {
        if (other.tag == "Player") {
          PlayerHealth player = other.GetComponent<PlayerHealth>();

          if (player != null) {
              animator.SetTrigger("attack");
              player.Health -= damage;
              print("Player Health: " + player.Health);
          }
        }
      } 
    }

}