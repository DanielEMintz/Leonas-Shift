using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public GameObject darkMode;
    public GameObject lightMode;

    bool light;

    private void Start()
    {
        light = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(light)
            {
                light = false;
                darkMode.SetActive(true);
                lightMode.SetActive(false);
            }
            else if(!light)
            {
                light = true;
                lightMode.SetActive(true);
                darkMode.SetActive(false);
            }
        }
    }
}
