using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    Vector3 basicAttackOffset;
    public Collider2D basicCollider;

    public float damage = 1f;

    private void Start() {
        basicAttackOffset = transform.position;
    }

    
    public void AttackRight() {
        basicCollider.enabled = true;
        transform.localPosition = basicAttackOffset;
    }

    public void AttackLeft() {
        basicCollider.enabled = true;
        transform.localPosition = new Vector2(basicAttackOffset.x * -1, basicAttackOffset.y);
    }

    public void StopAttack() {
        basicCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy!=null) {
                //print("Health: " + enemy.Health);
                //print("Damage :" + damage);
                enemy.Health -= damage;
                print("Health: " + enemy.Health);
                
            }
        }
    }
}
