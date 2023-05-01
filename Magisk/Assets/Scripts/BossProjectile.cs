using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float projectileSpeed = 10f; // velocidade do projetil
    public Rigidbody2D rb;

    Vector3 projectileOffset;

    public SpriteRenderer spriteRenderer;
    public BoxCollider2D collider;

    public float setDistance = 1f;
    public float damage = 1f;

    void Start()
    {
        projectileOffset = transform.position;
        spriteRenderer.enabled = false;
    }

    public void Fire()
    {
        
    }

    public void AttackRight(Vector3 targetPosition) {
        spriteRenderer.enabled = true;
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * projectileSpeed;
        spriteRenderer.flipX = false;

        collider.size = new Vector2(Mathf.Abs(collider.size.x), collider.size.y);
        print("AttackRight");
    }

    public void AttackLeft(Vector3 targetPosition) {
        spriteRenderer.enabled = true;
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * projectileSpeed;
        spriteRenderer.flipX = true;

        collider.size = new Vector2(-Mathf.Abs(collider.size.x), collider.size.y);
        print("AttackLeft");
        
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (other.tag == "Player") {
            if (player != null) {
                player.Health -= damage;
                Destroy(gameObject);
                print("Player Health: " + player.Health);
            }
        }
        else if (other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        
    }
}
