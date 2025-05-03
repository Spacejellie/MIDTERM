using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string[] firstDialogue;
    public string[] repeatDialogue;
    public string dialogueKey = "Seen_ThisDialogue"; // Unique key for this trigger
    public GameObject pressFPrompt;

    private bool playerInRange = false;
    private bool hasStartedDialogue = false;

    void Start()
    {
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
        }

        if (pressFPrompt != null)
        {
            pressFPrompt.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !hasStartedDialogue)
        {
            hasStartedDialogue = true;
            pressFPrompt.SetActive(false);

            if (PlayerPrefs.GetInt(dialogueKey, 0) == 0)
            {
                // First time dialogue
                PlayerPrefs.SetInt(dialogueKey, 1);
                dialogueManager.StartDialogue(firstDialogue);
            }
            else
            {
                // Repeat dialogue
                dialogueManager.StartDialogue(repeatDialogue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!hasStartedDialogue && pressFPrompt != null)
            {
                pressFPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (pressFPrompt != null)
            {
                pressFPrompt.SetActive(false);
            }
        }
    }
}