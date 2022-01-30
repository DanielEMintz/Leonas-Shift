using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{

    public float spinSpeed = 0.05f;
    public float spinRange = 12f;
    public float timePassed;


    private void Start()
    {
        timePassed = spinSpeed;
    }
    void Update()
    {
        if(timePassed <= Time.time)
        {
            timePassed += spinSpeed;
            transform.Rotate(0, 0, spinRange);
            Debug.Log("true");
        }
    }
}
