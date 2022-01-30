using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public GameObject continueButton;
    public PlayerDialog player;
    public GameObject dialogUI;
    public bool pressedButton;
    public bool inDialog;
    public SoundManagerScript SoundManager;


    private void Start()
    {
        dialogUI.SetActive(false);
        inDialog = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inDialog == false)
        {
            if (player.canDialog)
            {
                inDialog = true;
                dialogUI.SetActive(true);
                StartCoroutine(Type());
                SoundManager.PlaySound("text1");
            }
        }

        if (textDisplay.text == sentences[index])
        {
            //SoundManager.StopSound();
            continueButton.SetActive(true);
        }
        if (textDisplay.text == sentences[sentences.Length - 1]) //checks for the end of the dialog
        {
            dialogUI.SetActive(false);
            inDialog = false;
            index = 0;
            textDisplay.text = "";
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            if(index< sentences.Length - 1)
            {
                SoundManager.PlaySound("text2");
            }
            else if(index == sentences.Length - 1)
            { SoundManager.PlaySound("text1"); }
        } else {
            textDisplay.text = "";
        }
    }


}
