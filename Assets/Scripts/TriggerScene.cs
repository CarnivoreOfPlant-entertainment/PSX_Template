using UnityEngine;
using TMPro;

public class TriggerScene : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string textToDisplay = "Press <color=orange>[E]</color>";

    public bool isForInteracting;
    public bool isForSceneSwitching;

    public string sceneName;

    private bool inTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;

        if (isForSceneSwitching)
        {
            // Switch to the specified scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        text.gameObject.SetActive(true);
        text.text = "";
        text.text = textToDisplay;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        text.text = "";
    }

    private void Update()
    {
        if(inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isForInteracting)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                }
                
            }

        }
    }
}
