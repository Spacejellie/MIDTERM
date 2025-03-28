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

    // Start is called before the first frame update
    void Start()
    {
        dialogueDisplay.text = dialogue[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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
}
