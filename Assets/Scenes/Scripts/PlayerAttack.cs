using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackZone;
    [SerializeField] PlayerMovement movement;
    [SerializeField] BoxCollider2D attackCollider;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float attackDuration = 0.2f;

    float attackTimer = 0f;

    SpriteRenderer attackSprite;

    [SerializeField] Animator animator;



    void Start()
    {
        /*
        //Turn off the attack sprite
        attackSprite = attackZone.GetComponent<SpriteRenderer>();
        if (attackSprite != null)
        {
            attackSprite.enabled = false;
        }
        */
    }
    void Update()
    {

        Vector2 direction = movement.lastDirection;
        if (direction != Vector2.zero)
        {

            attackZone.localPosition = direction * attackRange;
            
        }

        if (Input.GetKey(KeyCode.Space))
        {
            attackTimer = attackDuration;
            attackCollider.enabled = true;
            animator.SetBool("isAttacking", true);
            
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attackCollider.enabled = false;
            animator.SetBool("isAttacking", false);
          
        }


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            if (enemy != null)
            {

            enemy.GetHit();
            Debug.Log("enemy hit");
            }
        }

    
    }


}
