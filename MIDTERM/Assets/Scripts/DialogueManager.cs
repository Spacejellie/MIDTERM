using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueDisplay;
    public GameObject pressFPrompt; // UI text that says "Press F to continue..."

    public string[] dialogue;
    public string nextSceneName; // Name of the scene to load after dialogue
    public int currentIndex = 0;

    public float typingSpeed = 0.05f;
    private bool isTyping = false;
    private bool dialogueActive = false;

    void Start()
    {
        StartDialogue(dialogue);
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.F))
        {
            if (isTyping)
            {
                // Skip typewriter effect and show full text
                StopAllCoroutines();
                dialogueDisplay.text = dialogue[currentIndex];
                isTyping = false;
                pressFPrompt.SetActive(true);
            }
            else
            {
                currentIndex++;
                if (currentIndex < dialogue.Length)
                {
                    StartCoroutine(TypeSentence(dialogue[currentIndex]));
                }
                else
                {
                    EndDialogue();
                }
            }
        }


    }

    public void StartDialogue(string[] newDialogue)
    {
        dialogue = newDialogue;
        currentIndex = 0;
        dialogueActive = true;
        gameObject.SetActive(true);
        StartCoroutine(TypeSentence(dialogue[currentIndex]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueDisplay.text = "";
        pressFPrompt.SetActive(false);

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        pressFPrompt.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueDisplay.text = "";
        pressFPrompt.SetActive(false);
        dialogueActive = false;
        gameObject.SetActive(false); // Optional: hide dialogue UI

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
