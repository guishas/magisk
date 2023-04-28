using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemProjectile : MonoBehaviour
{
    public float projectileSpeed = 10f; // velocidade do projetil
    public Rigidbody2D rb;

    Vector3 projectileOffset;

    public float setDistance = 1f;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        projectileOffset = transform.position;
    }

    public void Fire()
    {
        rb.velocity = new Vector2(projectileSpeed, 0f);
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (other.tag == "Player") {
            if (player != null) {
                player.Health -= 1f;
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
