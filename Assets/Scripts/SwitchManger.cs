using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManger : MonoBehaviour
{
    public List<GameObject> lightPlatforms = new List<GameObject>();
    public List<GameObject> darkPlatform = new List<GameObject>();
    List<GameObject> gravDark = new List<GameObject>();
    List<GameObject> gravLight = new List<GameObject>();
    public LightDark[] lightDarks;
    Spikes[] spikesScrips;


    BackGround BG;
    ExitDoor[] door;
    GravSwitch[] gravSwitch;
    bool inLight = true;

    public GameObject lightSpike;
    public GameObject darkSpike;
    bool switched;

    void Start()
    {
        gravSwitch = FindObjectsOfType<GravSwitch>();
        door = FindObjectsOfType<ExitDoor>();
        BG = BackGround.FindObjectOfType<BackGround>();
        gravSwitch = FindObjectsOfType<GravSwitch>();
        lightDarks = FindObjectsOfType<LightDark>();

        switched = false;




        foreach (var item in gravSwitch)
        {
            if (item.isLightSet)
            {
                gravLight.Add(item.gameObject);
            }
            else
            {
                gravDark.Add(item.gameObject);
            }
        }
        ActiveSet(gravDark, false);
        ActiveSet(gravLight, true);

        foreach (var item in lightDarks)
        {
            if (item.isLight)
            {
                lightPlatforms.Add(item.gameObject);
            }

            if (!item.isLight)
            {
                darkPlatform.Add(item.gameObject);
            }
        }
        ActiveSet(darkPlatform, false);
        ActiveSet(lightPlatforms, true);
    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (var item in door)
            {
                item.toSwitch = true;

            }
            BG.toChange = true;
            if (!switched)
            {
                switched = true;
                darkSpike.SetActive(true);
                lightSpike.SetActive(false);
            }
            else if (switched)
            {
                switched = false;
                darkSpike.SetActive(false);
                lightSpike.SetActive(true);
            }

            foreach (var item in gravSwitch)
            {
                item.toSwitch = true;
            }

            if (inLight)
            {

                inLight = false;

                ActiveSet(gravLight, false);
                ActiveSet(gravDark, true);
                ActiveSet(lightPlatforms, false);
                ActiveSet(darkPlatform, true);
            }
            else
            {
                inLight = true;

                ActiveSet(gravLight, true);
                ActiveSet(gravDark, false);
                ActiveSet(lightPlatforms, true);
                ActiveSet(darkPlatform, false);

            }
        }
    }

    void ActiveSet(List<GameObject> objects, bool activeSet)
    {
        foreach (var item in objects)
        {
            item.SetActive(activeSet);
        }

    }
}
