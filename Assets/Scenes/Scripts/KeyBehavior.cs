using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();

            if (player != null)
            {
                player.AddKey();
                Destroy(gameObject);
            }
        }
    }
}
