using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemNameDic : MonoBehaviour

    //----------------Variables-----------------------

{
    public string itemName; //Name of the item
    public int itemNumber = 1; // Quantity of the Item (default is 1
    public int objectIndex; // Index used in the Dialogue Manager
    public PlayerMovDic myPlayer; //Reference to the player script
    public DialogueManager dialogueManager; // Reference to the dialogue system
    public GameObject pickUp; // UI indicator (e,g, "Press F to pick up")
    private bool isPlayerNear = false;
    public string[] itemDialogue; // Drag in specific dialogue for this item in the Inspector


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovDic>(); //Find and assign the PlayerMoveDic script
        dialogueManager = FindObjectOfType<DialogueManager>(); // Find and assign the DialogueManager script
        pickUp.SetActive(false); // Hide the pickup indicator at the start

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))// If player presses "E"
        {
            Interact(); //Update dialogue manager
            AddItem(); // Add item to the inventory
            pickUp.SetActive(false); //Hide pickup prompt
            Destroy(gameObject); // Remove item from the world
            isPlayerNear = false;
            Debug.Log(" Pick Up Key");
        }

        if (isPlayerNear && Input.GetKeyDown(KeyCode.F)) // If player presses "F"
        {
            // This could be used for other interactions if needed
            Debug.Log("Player is near the item: " + itemName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Detect player in range
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear =true;
            if (pickUp != null) pickUp.SetActive(true); // Show the pickup prompt
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear =false;
            if (pickUp != null) pickUp.SetActive(false); // Hide the pickup prompt
        }
    }

    /// <summary>
    /// The method is triggered while the player stays inside the items collider
    /// It Enables the "Press F to pick up" UI (pickUP)
    /// If the player presses "F", the following happens:
    /// 
    ///     - Calls Interact() -> Updates the dialogue system
    ///     - Calls AddItem() -> Adds item to player's inventory
    ///     - Destroys the item object (removing it from the scene)
    ///     
    /// </summary>

    public void AddItem() //Handles Inventory Management
    {
        if (myPlayer.myInventoryDict.ContainsKey(itemName))
            {
            myPlayer.myInventoryDict[itemName] += itemNumber;
            
        }
        else
        {
            myPlayer.myInventoryDict.Add(itemName, itemNumber);
        }
        myPlayer.DisplayInventory();
    }

    public void Interact() //Updates Dialogue System
    {
        dialogueManager.StartDialogue(itemDialogue);
    }
}
