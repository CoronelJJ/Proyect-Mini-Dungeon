
using Unity.Mathematics;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
  
    [SerializeField] float _moveSpeed;
    [SerializeField] float _attackRadius;
    [SerializeField] Transform _parent;

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] EnemyAttack _enemyAttack;
    Vector3 _direction3;
    Quaternion _rotation;

    Vector2 _movement;


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetPositionAndRotation(out _direction3, out _rotation);
            _enemyAttack.playerPos = collision.transform.position;
            _enemyAttack.Attack();

            float distanceToPlayer = Vector2.Distance(transform.position, _direction3);
            if (distanceToPlayer > _attackRadius)
            {
                _movement = (_direction3 - transform.position).normalized;

            }
            else
            {
                _movement = Vector2.zero;
            }

            
            if (_movement.x < 0 && _parent.localScale.x > 0)
            {
                _parent.localScale = new Vector3(_parent.localScale.x * -1, _parent.localScale.y);
            }
            else if (_movement.x > 0 && _parent.localScale.x < 0)
            {
                _parent.localScale = new Vector3(_parent.localScale.x * -1, _parent.localScale.y);
            }

            _rb.linearVelocity = _movement * _moveSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rb.linearVelocity = Vector2.zero;
            _enemyAttack.playerPos = Vector3.zero;
        }
    }
}
