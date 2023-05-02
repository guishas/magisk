using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float movementSpeed = 3f;

    public float health = 100f;

    public DetectionZone detectionZone;

    Animator animator;

    private SpriteRenderer spriteRenderer;

    //public HealthBar healthBar;

    public GameObject bossProjectilePrefab;

    public GameObject player;

    public Rigidbody2D rb;

    public Transform projectileSpawnPoint;

    public float minFireInterval = 1f;
    public float maxFireInterval = 3f;

    private const float SHOT_COOLDOWN = 0.5f;

    // The timer to keep track of time between projectile fires
    private float fireTimer;

    Vector3 posicaoPlayerNoMundo;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //healthBar.SetMaxHealth(health);

        StartCoroutine(FireProjectiles());
    }

    void Update()
    {
        posicaoPlayerNoMundo = player.transform.position;

    }


    void FixedUpdate() {
        if (detectionZone.detectedObj.Count > 0)
        {
            fireTimer += Time.deltaTime;
            Collider2D target = detectionZone.detectedObj[0];
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * movementSpeed;
            if (fireTimer >= SHOT_COOLDOWN){
                FireProjectiles();

            }

            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }


    public float Health {
        set {
            if (value < health) {
                animator.SetTrigger("hit");
            }

            health = value;
            //healthBar.SetHealth(health);
            if (health <= 0){
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public void Defeated()
    {
        animator.SetBool("isAlive", false);
    }


    IEnumerator FireProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (detectionZone.detectedObj.Count > 0) {
                print("player" + posicaoPlayerNoMundo.x);
                print("boss" +transform.position.x);
                if (posicaoPlayerNoMundo.x < transform.position.x) {
                    GameObject projectile = Instantiate(bossProjectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
                    projectile.GetComponent<BossProjectile>().AttackLeft();
                    fireTimer = 0f;
                }
                else {
                    GameObject projectile = Instantiate(bossProjectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
                    projectile.GetComponent<BossProjectile>().AttackRight();
                    fireTimer = 0f;
                }
            }

        }
    }
}
