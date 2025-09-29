using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int hp = 50;
    [SerializeField] GameObject drops;

    [SerializeField] SpriteRenderer sprite;
    float iframe;
    float changeColorTimer;


    void Update()
    {

        if (iframe > 0)
        {
            iframe -= Time.deltaTime;
        }

        if (changeColorTimer > 0)
        {
            changeColorTimer -= Time.deltaTime;
            if (changeColorTimer <= 0)
            {
                sprite.color = Color.white;
            }
        }

    }

    public void GetHit()
    {
        if (iframe <= 0)
        {
            ReceiveDamage();
            iframe = 1f;

        }

    }
    void ReceiveDamage()
    {
        HitColorChange();
        hp -= 20;
        Debug.Log(hp);


        if (hp <= 0)
        {
            
            Destroy(gameObject);
        }
    }

    void HitColorChange()
    {
        sprite.color = Color.red;
        changeColorTimer = 0.2f;
    }

    void OnDestroy()
    {
        RoomManager rm = GetComponentInParent<RoomManager>();
        if (rm != null){
            rm.EnemyDied();
        }
    }
}
