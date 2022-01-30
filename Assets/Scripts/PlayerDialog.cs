using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{

    public bool canDialog;
    public GameObject catQuestiomark;

    private void Start()
    {
        canDialog = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Cat"))
        {
            canDialog = true;
            catQuestiomark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Cat"))
        {
            canDialog = false;
            catQuestiomark.SetActive(false);
        }
    }

}
