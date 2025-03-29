using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogueCutscene : MonoBehaviour
{

    public TextMeshProUGUI dialogueDisplay;
    public string[] dialogue = new string[5];
    public int currentIndex = 0;
    public bool keyPressed = false; 


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
                keyPressed = true;
                Debug.Log("Transitioning to Front Rooms");
                StartCoroutine(WaitAndLoadScene(1f, "Front Rooms"));

            }
        }
    }

    private IEnumerator WaitAndLoadScene(float waitTime, string sceneName)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
