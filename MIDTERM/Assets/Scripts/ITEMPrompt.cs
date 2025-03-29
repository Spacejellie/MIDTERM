using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEMPrompt : MonoBehaviour 
{

    public GameObject dialoguePrompt;
    private bool isPlayerNear = false;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKey(KeyCode.F))
        {
            Debug.Log("Looking at Item");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            dialoguePrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialoguePrompt.SetActive(false);
        }
    }
}
