using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    Health playerHealth;
    ExitDoor exit;
    bool canMenu;
    public GameObject menu;
    public Dialog player;



    void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        exit = FindObjectOfType<ExitDoor>();
        canMenu = true;
    }
    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && canMenu)
        {
                menu.SetActive(true);
                canMenu = false;
                player.inDialog = true; // freeze player on menu
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !canMenu)
        {
            menu.SetActive(false);
            canMenu = true;
            player.inDialog = false;
        }
    }


    public void MoveToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMenu()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(0);
    }
}
