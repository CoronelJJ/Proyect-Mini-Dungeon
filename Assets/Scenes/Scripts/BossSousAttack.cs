using UnityEngine;
using System.Linq;

public class BossSousAttack : MonoBehaviour
{
    
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject soulPrefab; 
    [SerializeField] private float attackCD = 3f;     

    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnAttack();
            timer = attackCD; 
        }
    }

    private void SpawnAttack()
    {
       
        int[] indices = Enumerable.Range(0, spawnPoints.Length)
                                  .OrderBy(x => Random.value)
                                  .Take(3)
                                  .ToArray();

        foreach (int i in indices)
        {
            Instantiate(soulPrefab, spawnPoints[i].position, Quaternion.identity);
        }
    }
}

