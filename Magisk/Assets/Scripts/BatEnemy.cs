using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    
    Animator animator;

    public float damage = 1f;

    public DetectionZone detectionZone;

    SpriteRenderer spriteRenderer;

    public float movementSpeed = 1f;

    public float setDistance = 1f;

    public float health = 1f;

    public Rigidbody2D rb;

    void FixedUpdate() {
        if(detectionZone.detectedObj.Count > 0) {
            //print("bat detected");
            Collider2D target = detectionZone.detectedObj[0];
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * movementSpeed;
            
            spriteRenderer.enabled = true;

            if (direction.x > 0) {
                spriteRenderer.flipX = true;
            } else {
                spriteRenderer.flipX = false;
            }
            
        }
        else {
            rb.velocity = Vector2.zero;
        }
            
    }
    
    public float Health {
        set {
            health = value;
            if (health <= 0){
                RemoveObject();
            }
        }
        get {
            return health;
        }
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
      float distance = Vector3.Distance(transform.position, other.gameObject.transform.position);

      if (distance <= setDistance) {
        if (other.tag == "Player") {
          PlayerHealth player = other.GetComponent<PlayerHealth>();

          if (player != null) {
            if(health > 0){
                player.Health -= damage;
                print("Player Health: " + player.Health);
            }
          }
        }
      } 
    }

    public void RemoveObject() {
        Destroy(gameObject);
    }

}
