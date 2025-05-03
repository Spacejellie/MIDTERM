using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovDic : MonoBehaviour
{
    public GameObject player;
    public Dictionary<string, int> myInventoryDict = new Dictionary<string, int>();
    public TextMeshProUGUI inventoryDisplay;

    public float speed = 0.03f;
    private bool isPlayerInTrigger = false;
    private string triggerTag = ""; // Store the tag of the trigger

    public static PlayerMovDic Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        inventoryDisplay = GameObject.FindGameObjectWithTag("INV").GetComponent<TextMeshProUGUI>();
        DisplayInventory();
    }

    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.W)) player.transform.position += Vector3.up * speed;
        if (Input.GetKey(KeyCode.S)) player.transform.position += Vector3.down * speed;
        if (Input.GetKey(KeyCode.A)) player.transform.position += Vector3.left * speed;
        if (Input.GetKey(KeyCode.D)) player.transform.position += Vector3.right * speed;

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            //What is a switch statement?
            //A switch statement is a control statement that allows you to execute
            //different parts of code based on the value of a variable or expression.
            //it is used to simplify complex if-else statements.

            //What is a case statement?

            //A case statement is used in switch statements to define a block of code
            //that will execute if the case matches the switch expression.
            //It is used to handle different values of the switch expression.

            //what is a break statement?

            //A break statement is used to exit a switch statement or loop.
            //It prevents the execution from falling through to the next case.
            //It is used to terminate the current case and exit the switch statement.

            //What is a couroutine?

            //A coroutine is a special function in Unity that allows you to pause execution
            //and yield control back to Unity for a specified amount of time.

            switch (triggerTag)
            
            {
                case "kitchen":
                    StartCoroutine(WaitAndLoadScene(1f, "Kitchen"));
                    break;
                case "pantry":
                    StartCoroutine(WaitAndLoadScene(1f, "Pantry"));
                    break;
                case "front":
                    StartCoroutine(WaitAndLoadScene(1f, "Front Rooms"));
                    break;
                case "stairs":
                    StartCoroutine(WaitAndLoadScene(1f, "2FL"));
                    break;
                case "back_front":
                    StartCoroutine(WaitAndLoadScene(1f, "Front Rooms"));
                    break;
                case "g-room":
                    StartCoroutine(WaitAndLoadScene(1f, "Granny's Room"));
                    break;
                case "back_2FL":
                    StartCoroutine(WaitAndLoadScene(1f, "2FL"));
                    break;

                default:
                    Debug.LogWarning("Unknown trigger tag: " + triggerTag);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kitchen") || collision.CompareTag("front") || collision.CompareTag("stairs")
            || collision.CompareTag("pantry") || collision.CompareTag("back_front")
            || collision.CompareTag("g-room") || collision.CompareTag("back_2FL")) // || means "or"
        {
            isPlayerInTrigger = true;
            triggerTag = collision.tag; // Stores the tag of the trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("kitchen") || collision.CompareTag("front") || collision.CompareTag("stairs")
            || collision.CompareTag("pantry") || collision.CompareTag("back_front")
            || collision.CompareTag("g-room") || collision.CompareTag("back_2FL"))
        {
            isPlayerInTrigger = false;
            triggerTag = ""; // Clears the tag when exiting the trigger
        }
    }


    private IEnumerator WaitAndLoadScene(float waitTime, string sceneName)

    //what is the purpose of the IEnumerator?
    //The purpose of the IEnumerator is to allow the function to yield execution
    //and wait for a specified amount of time before continuing to the next line of code.

    //What is the purpose of the yield return statement?
    //The purpose of the yield return statement is to pause the execution of the coroutine
    //and return control to Unity until the specified wait time has passed.
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

    public void DisplayInventory()
    {
        if (inventoryDisplay == null)
        {
            Debug.LogError("Display UI not assigned");
            return;
        }

        inventoryDisplay.text = "Inventory:\n";
        foreach (var item in myInventoryDict)
        {
            inventoryDisplay.text += $"Item: {item.Key}, Quantity: {item.Value}\n";
        }
    }
}
