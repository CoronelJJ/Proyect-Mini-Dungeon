using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestBehavoir : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Algo entró: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Victory");
            SceneManager.LoadScene(2);
        }
    
    }
}
