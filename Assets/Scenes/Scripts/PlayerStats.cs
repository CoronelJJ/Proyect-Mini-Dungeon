using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int keyCounter;
    [SerializeField] int hp;


    public void addKey()
    {
        keyCounter++;
    }

    public bool consumeKey()
    {
        if (keyCounter > 0)
        {
            keyCounter--;
            return true;
        }

        return false;
    }
}
