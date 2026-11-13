using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickThroughText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Set the full text immediately so TMP knows the tags exist
        textComponent.text = lines[index];

        // Hide all characters initially
        textComponent.maxVisibleCharacters = 0;

        // Force the text info to update immediately to get accurate character counts
        textComponent.ForceMeshUpdate();

        // Get the total number of actual renderable characters (tags are ignored automatically)
        int totalVisibleCharacters = textComponent.textInfo.characterCount;

        // Slowly reveal characters one by one
        for (int i = 0; i <= totalVisibleCharacters; i++)
        {
            textComponent.maxVisibleCharacters = i;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene(sceneName);
            gameObject.SetActive(false);
        }
    }
}
