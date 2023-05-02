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
        print("OnTriggerEnter2D");
        print("other.tag: " + other.tag);
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            BatEnemy bat = other.GetComponent<BatEnemy>();
            Boss boss = other.GetComponent<Boss>();
            GolemEnemy golem = other.GetComponent<GolemEnemy>();

            if (enemy!=null) {
                enemy.Health -= damage;
                print("Health: " + enemy.Health);
            }
            if (bat!=null) {
                bat.Health -= damage;
                print("Health: " + bat.Health);
            }
            if (boss!=null) {
                boss.Health -= damage;
                print("Health: " + boss.Health);
            }
            if (golem!=null) {
                golem.Health -= damage;
                print("Health: " + golem.Health);
            }
        }
    }
}
