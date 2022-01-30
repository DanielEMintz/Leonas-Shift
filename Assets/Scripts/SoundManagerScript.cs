using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip  jumpSound, walkingSound, textSound1, textSound2, textSound3;
    public AudioClip playerDamage;
    static AudioSource audioSrc;


    void Start()
    {
        //playerDamage = Resources.Load<AudioClip>("damage");
        walkingSound = Resources.Load<AudioClip>("walk");

        audioSrc = GetComponent<AudioSource>();
    }


    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            //case "land":
            //    audioSrc.PlayOneShot(landSound);
            //    break;
            case "walk":
                audioSrc.PlayOneShot(walkingSound);
                break;
            case "damage":
                audioSrc.PlayOneShot(playerDamage);
                break;
            case "text1":
                audioSrc.PlayOneShot(textSound1);
                break;
            case "text2":
                audioSrc.PlayOneShot(textSound2);
                break;
            case "text3":
                audioSrc.PlayOneShot(textSound3);
                break;
        }
    }

    public void StopSound()
    {
        audioSrc.Stop();
    }
}

