using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    Animator animator;

    public GolemDZ detectionZone;

    public GameObject projectilePrefab;

    public SpriteRenderer spriteRenderer;

    public float movementSpeed = 1f;

    public float setDistance = 1f;

    public Transform projectileSpawnPoint;

    private float timeSinceLastShot;

    private const float SHOT_COOLDOWN = 2f;

    public Rigidbody2D rb;

    public GameObject player;
    //public GameObject golem;
    
    Vector3 posicaoPlayerNoMundo;

    Vector3 posicaoPlayerNoGolem;


    void Update()
    {
        // Obtém a posição do objeto 2 em relação ao mundo
        posicaoPlayerNoMundo = player.transform.position;

        // Obtém a posição do objeto 2 em relação ao objeto 1

    }

    void FixedUpdate() {
        timeSinceLastShot += Time.deltaTime;


        if(detectionZone.detectedObj.Count > 0) {
            if(timeSinceLastShot >= SHOT_COOLDOWN) {
                SpawnProjectile();
                timeSinceLastShot = 0f;
            }
        }
    }

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
        animator.SetBool("isAlive", true);
        //rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnProjectile());
    }

    IEnumerator SpawnProjectile() {
        while (true) {
            yield return new WaitForSeconds(2f); // espera 2 segundos
            if (detectionZone.detectedObj.Count > 0) {
                if (posicaoPlayerNoMundo.x < transform.position.x) {
                    animator.SetTrigger("shoot");
                    GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
                    projectile.GetComponent<GolemProjectile>().AttackLeft();
                    spriteRenderer.flipX = true;

                }
                else {
                    animator.SetTrigger("shoot");
                    GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
                    projectile.GetComponent<GolemProjectile>().AttackRight();
                    spriteRenderer.flipX = false;
                }
                
            }
        }
    }

    public void Defeated() {
        animator.SetBool("isAlive", false);
    }

    public void RemoveObject() {
        Destroy(gameObject);
    }

}
