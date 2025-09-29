using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int keyCounter;
    [SerializeField] int hp = 40;
    [SerializeField] int maxHP = 60;
    [SerializeField] SpriteRenderer sprite;


    float flashTimer;
    float iframe;

    bool vulnerable = true;


    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0)
            {
                sprite.color = Color.white;
            }
        }

        if (iframe > 0)
        {
            iframe -= Time.deltaTime;
            if (iframe <= 0)
            {
                vulnerable = true;
            }
        }
    }
    public void AddKey()
    {
        keyCounter++;
    }

    public bool ConsumeKey()
    {
        if (keyCounter > 0)
        {
            keyCounter--;
            return true;
        }

        return false;
    }

    public void IncreaseHealth()
    {
        if (hp < maxHP)
        {

            hp += 10;
        }
    }

    public void DecreaseHealth()
    {
        if (vulnerable)
        {
            vulnerable = false;
            hp -= 10;
            flashTimer = 0.1f;
            sprite.color = Color.red;
            iframe = 2f;
            Debug.Log("hit");
            Debug.Log(hp);
            
        }

        if (hp <= 0)
        {
            Debug.Log("dead");
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        SceneManager.LoadScene(3);
    }
}
