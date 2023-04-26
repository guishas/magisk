using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementInput;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float CollisionOffset = 0.01f;
    bool canMove = true;

    public BasicAttack basicAttack;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {

        if (canMove) {
        
            if(movementInput != Vector2.zero) {
                bool success = TryMove(movementInput);

                if (!success) {
                    success = TryMove(new Vector2(movementInput.x, 0f));
                }

                if (!success) {
                    TryMove(new Vector2(0f, movementInput.y));
                }

                animator.SetBool("isWalking", success);

            } else {
                animator.SetBool("isWalking", false);
            }

            if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            } else if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
            }
        }

    }

    private bool TryMove(Vector2 direction){
        if (direction != Vector2.zero) {
            int count = rb.Cast(
                direction, 
                movementFilter, 
                castCollisions, 
                moveSpeed * Time.fixedDeltaTime + CollisionOffset); 
 
            if(count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("magicAttack");
    }

    public void BasicAttack() {
        LockMovement();
        if (spriteRenderer.flipX) {
            basicAttack.AttackLeft();
        } else {
            basicAttack.AttackRight();
        }
    }

    public void EndBasicAttack() {
        UnlockMovement();
        basicAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}