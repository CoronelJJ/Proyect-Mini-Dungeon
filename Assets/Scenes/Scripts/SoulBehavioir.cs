using UnityEngine;

public class SoulBehavioir : MonoBehaviour
{
 
    [SerializeField] private float speed = 4f;
    [SerializeField] private float lifeTime = 5f;

    private void Update()
    {
    
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
