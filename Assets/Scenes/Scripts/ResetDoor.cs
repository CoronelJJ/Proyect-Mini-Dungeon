using UnityEngine;

public class ResetDoor : MonoBehaviour
{
    [SerializeField] DoorBehavior doorsGrid;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorsGrid.closeTheDoor();
        }
    }
}
