using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //VARIABLES

    public TextMeshProUGUI dialogueDisplay;
    public string[] dialogue = new string[5];
    public int currentIndex = 0;
    private bool isPlayerNear = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueDisplay.text = dialogue[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            if (currentIndex < dialogue.Length)
            {
                dialogueDisplay.text = dialogue[currentIndex];
                currentIndex++;
            }

            else
            {
                dialogueDisplay.text = "";
                currentIndex = 0;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scene"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Scene"))
        {

            isPlayerNear = false;
            dialogueDisplay.text = "";
            currentIndex = 0;
        }
    }
}
