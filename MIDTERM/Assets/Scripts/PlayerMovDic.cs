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
    // Flag to track trigger state

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

        // Scene transition when pressing "F" inside trigger
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene("Kitchen");
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene("2FL");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kitchen"))
        {
            isPlayerInTrigger = true;
        }

        if (collision.CompareTag("stairs"))
        {
            isPlayerInTrigger = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("kitchen"))
        {
            isPlayerInTrigger = false;
        }

        if (collision.CompareTag("stairs"))
        {
            isPlayerInTrigger = false;
        }
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