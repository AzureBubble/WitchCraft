using MainControl;
using SceneManagement.Scene;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AutoDialog : MonoBehaviour
{
    public string[] dialogue;
    public float letterPause = 0.1f;
    public float conversationPause = 2f;
    public string nextSceneName;
    private Text dialogText;
    private bool isSkipping = false; // Flag to determine if the user is skipping the conversation

    private void Start()
    {
        dialogText = GetComponent<Text>();
        StartCoroutine(ShowDialog());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSkipping = true;
        }
    }

    private IEnumerator ShowDialog()
    {
        foreach (string line in dialogue)
        {
            if (line == string.Empty)
            {
                break;
            }
            if (isSkipping) // Check if the user is skipping the conversation
            {
                dialogText.text = ""; // Clear the dialog text if the user skips
                break;
            }
            for (int i = 0; i < line.Length; i++)
            {
                dialogText.text += line[i];
                yield return new WaitForSeconds(letterPause);
            }
            yield return new WaitForSeconds(conversationPause);
            dialogText.text = ""; // Clear the dialog text after each line
        }
        // Automatically transition to the next scene when the conversation is finished
        //SceneManager.LoadScene(nextSceneName);
        yield return new WaitForSeconds(0.05f);
        MainController.Instance.SceneManager.DynamicSetScene(new Level1Scene());
    }

    public void SkipConversation()
    {
        isSkipping = true;
    }
}