using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    [SerializeField] Sprite BlackBG;
    [SerializeField] Sprite WhiteBG;

    SpriteRenderer sprite;

    public bool toChange = false;
    bool islight = true;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toChange)
        {
            if (islight)
            {
                sprite.sprite = BlackBG;
                islight = false;
                toChange = false;
            }
            else
            {
                sprite.sprite = WhiteBG;
                islight = true;
                toChange = false;
            }
        }
    }
}
