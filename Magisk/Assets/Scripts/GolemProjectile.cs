using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemProjectile : MonoBehaviour
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
        //rb = GetComponent<Rigidbody2D>();
        projectileOffset = transform.position;
        spriteRenderer.enabled = false;
    }

    public void Fire()
    {
        
    }

    public void AttackRight() {
        spriteRenderer.enabled = true;
        rb.velocity = new Vector2(projectileSpeed, 0f);
        spriteRenderer.flipX = false;
        collider.offset = new Vector2(Mathf.Abs(collider.offset.x), collider.offset.y);
        print("AttackRight");
    }

    public void AttackLeft() {
        spriteRenderer.enabled = true;
        rb.velocity = new Vector2(projectileSpeed * -1, 0f);
        spriteRenderer.flipX = true;
        collider.offset = new Vector2(Mathf.Abs(collider.offset.x) * -1, collider.offset.y);
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
