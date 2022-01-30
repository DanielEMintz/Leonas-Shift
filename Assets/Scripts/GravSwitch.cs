using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravSwitch : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] Sprite Dark;
    [SerializeField] Sprite light;
    public bool isLightSet;

    bool isLight = true;
    public bool toSwitch = false;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
            if (isLightSet)
            {
                sprite.sprite = light;
                
            }
            else
            {
                sprite.sprite = Dark;
                
            }
        }
    }


