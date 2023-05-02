using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float movementSpeed = 3f;

    public float health = 100f;

    private float maxHealth = 100f;

    public DetectionZone detectionZone;

    Animator animator;

    private SpriteRenderer spriteRenderer;

    //public HealthBar healthBar;

    public GameObject bossProjectilePrefab;

    public GameObject player;

    public GameObject bossProjectile;

    public Rigidbody2D rb;

    public Transform projectileSpawnPoint;

    public float minFireInterval = 1f;
    public float maxFireInterval = 3f;

    private float SHOT_COOLDOWN = 1f;

    // The timer to keep track of time between projectile fires
    private float fireTimer;

    Vector3 posicaoPlayerNoMundo;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //healthBar.SetMaxHealth(health);

        maxHealth = health;
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

            if (Health >= maxHealth * 0.75f)
            {
                SHOT_COOLDOWN = 1f;
                bossProjectilePrefab.GetComponent<BossProjectile>().projectileSpeed = 1f;
                if (fireTimer >= SHOT_COOLDOWN){
                    FireProjectiles();
                }
            }

            else if (Health <= maxHealth * 0.75f && Health > maxHealth * 0.5f)
            {
                SHOT_COOLDOWN = 0.75f;
                bossProjectilePrefab.GetComponent<BossProjectile>().projectileSpeed = 3f;
                if (fireTimer >= SHOT_COOLDOWN){
                    FireProjectiles();
                }
            }
            else if (Health <= maxHealth * 0.5f && Health > maxHealth * 0.25f)
            {
                SHOT_COOLDOWN = 0.5f;
                bossProjectilePrefab.GetComponent<BossProjectile>().projectileSpeed = 6f;
                if (fireTimer >= SHOT_COOLDOWN){
                    FireProjectiles();
                }
            }
            else if (Health <= maxHealth * 0.25f)
            {
                SHOT_COOLDOWN = 0.25f;
                bossProjectilePrefab.GetComponent<BossProjectile>().projectileSpeed = 9f;
                if (fireTimer >= SHOT_COOLDOWN){
                    FireProjectiles();
                }
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

    public void RemoveObject()
    {
        Destroy(gameObject);
        FindObjectOfType<CanvaManager>().showFinalDialog();
    }


    IEnumerator FireProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(SHOT_COOLDOWN);
            if (detectionZone.detectedObj.Count > 0) {
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
