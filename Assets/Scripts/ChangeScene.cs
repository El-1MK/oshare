using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = (currentScene.buildIndex + 1)%SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
