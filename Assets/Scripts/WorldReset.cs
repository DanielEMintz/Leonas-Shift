using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldReset : MonoBehaviour
{
    public PlayerMovement player;


    void Update()
    {
        if(player.respawned)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
