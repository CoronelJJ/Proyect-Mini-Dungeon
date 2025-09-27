using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int hp = 50;
    [SerializeField] GameObject drops;
    float iframe;

    void Start()
    {

    }

    void Update()
    {

        if (iframe > 0)
        {
            iframe -= Time.deltaTime;
        }
    }

    public void getHit()
    {
        if (iframe <= 0)
        {
            receiveDamage();
            iframe = 0.5f;
            
        }

    }
    void receiveDamage()
    {
       
        hp -= 20;
        Debug.Log(hp);

        if (hp <= 0)
        {
            Instantiate(drops, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
