using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCall : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
