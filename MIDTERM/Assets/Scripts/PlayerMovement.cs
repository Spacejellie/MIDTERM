using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    public GameObject player;
    public float speed = 0.2f;

    public List<string> myInventory;
    public bool inventoryFull = false;
    // Start is called before the first frame update
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

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed;
        }

        if (myInventory.Count > 5)
        {
            inventoryFull = true;
        }

        if (myInventory.Count <= 5)
        {
            inventoryFull = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when colliding with a game object tagged as "enemy", destroy the player
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //when entering a trigger destroy the player
        if (other.tag == "Death")
        {
            Destroy(player);
        }
    }

    public void addInventory(string item)
    {
        if (inventoryFull == false)
        {
            myInventory.Add(item);
        }
    }
}
