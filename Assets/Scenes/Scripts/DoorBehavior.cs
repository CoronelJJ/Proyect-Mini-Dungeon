using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    Transform closedDoor;
    Transform openDoor;
    bool doorClosed = true;

    void Start()
    {
        closedDoor = transform.Find("DoorClosed");
        openDoor = transform.Find("DoorOpened");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();

            if (player != null)
            {
                if (player.consumeKey())
                {
                    openTheDoor();
                }
            }
        }

    }

    void openTheDoor()
    {
        if (doorClosed)
        {
            closedDoor.gameObject.SetActive(false);
            openDoor.gameObject.SetActive(true);
            doorClosed = false;
        }
    }
    public void closeTheDoor()
    {
        if (!doorClosed)
        {
            closedDoor.gameObject.SetActive(true);
            openDoor.gameObject.SetActive(false);
            doorClosed = true;
        }
    }


}
