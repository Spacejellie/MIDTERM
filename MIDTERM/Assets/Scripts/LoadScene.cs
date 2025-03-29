using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    public PlayerMovDic myPlayer;

    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovDic>(); //Find and assign the PlayerMoveDic script
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                myPlayer.newScene = true;
                SceneManager.LoadScene(sceneToLoad);
                StartCoroutine(WaitAndLoadScene(1f, sceneToLoad)); // Add a delay before loading the scene
            }
        }
    }

    private IEnumerator WaitAndLoadScene(float waitTime, string sceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
