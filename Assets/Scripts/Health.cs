using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// Add this component to a Gameobjet to make it mortal
/// Don't Forget to attach a slider component
public class Health : MonoBehaviour
{
	public Image[] hps;

    Vector2 spawn;

	public int hp = 3;


    private void Start()
    {
        spawn = FindObjectOfType<StartSpawn>().transform.position;
    }


    private void Update()
    {
        if (hp == 2)
        {
            hps[2].gameObject.SetActive(false);
        }
        else if (hp == 1)
        {
            hps[1].gameObject.SetActive(false);

        }
        else if (hp == 0)
        {
            hps[0].gameObject.SetActive(false);
            //dead
            GameOver();
        }

        
    }

    public void HpReduce()
    {
        //hp--;
        //ReSpwan();
    }

    void ReSpwan()
    {
        transform.position = spawn;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}

