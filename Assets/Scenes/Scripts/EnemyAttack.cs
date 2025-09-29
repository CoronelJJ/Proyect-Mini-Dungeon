using UnityEngine;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform attackZone;
    [SerializeField] CircleCollider2D attackCollider;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float attackDuration = 0.2f;
    [SerializeField] float attackCooldown = 1f;

    [HideInInspector] public Vector3 playerPos;

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector3 attackDirection;

    HashSet<GameObject> alreadyHit = new HashSet<GameObject>();

    void Start()
    {
        attackCollider.enabled = false;
        playerPos = Vector3.zero;
    }

    void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            attackZone.localPosition = attackDirection * attackRange;

            if (attackTimer <= 0f)
            {
                EndAttack();
            }

            return; 
        }

        
        if (playerPos != Vector3.zero)
        {
            Vector3 direction = (playerPos - transform.position).normalized;
            attackDirection = transform.InverseTransformDirection(direction);
            attackZone.localPosition = attackDirection * attackRange;
        }
    }

    public void Attack()
    {
        if (isAttacking || cooldownTimer > 0f || playerPos == Vector3.zero)
            return;


        isAttacking = true;
        attackTimer = attackDuration;
        attackCollider.enabled = true;
    }

    void EndAttack()
    {
        isAttacking = false;
        attackCollider.enabled = false;
        cooldownTimer = attackCooldown;
        alreadyHit.Clear();

    }

    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !alreadyHit.Contains(other.gameObject))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.DecreaseHealth();
                Debug.Log("hit from enemy");
                alreadyHit.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerPos = Vector3.zero;
    }
}

