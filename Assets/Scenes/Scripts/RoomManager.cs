using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject keyPrefab;
    [SerializeField] Transform spawnPoint;

    int enemiesAlive;

    void Start()
    {
        enemiesAlive = transform.childCount;
    }

    public void EnemyDied()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("¡Todos muertos! Llave creada");
        }
    }
}
