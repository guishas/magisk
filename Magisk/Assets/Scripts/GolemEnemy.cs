using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    //Animator animator;

    public float damage = 1f;

    public GolemDZ detectionZone;

    public GameObject projectilePrefab;

    public float movementSpeed = 1f;

    public float setDistance = 1f;

    public Transform projectileSpawnPoint;

    private float timeSinceLastShot;

    private const float SHOT_COOLDOWN = 2f;

    public Rigidbody2D rb;

    

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
            if (value < health) {
                //animator.SetTrigger("hit");
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
        //animator = GetComponent<Animator>();
        //animator.SetBool("isAlive", true);
        //rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnProjectile());
    }

    IEnumerator SpawnProjectile() {
        while (true) {
            yield return new WaitForSeconds(2f); // espera 2 segundos
            if (detectionZone.detectedObj.Count > 0) { // verifica se ainda há um objeto detectado
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
                projectile.GetComponent<GolemProjectile>().Fire();
            }
        }
    }

    public void Defeated() {
        //animator.SetBool("isAlive", false);
    }

    public void RemoveObject() {
        Destroy(gameObject);
    }


    /* public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    } */
}
