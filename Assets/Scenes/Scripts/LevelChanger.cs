using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void SceneChanger(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
     }
}
