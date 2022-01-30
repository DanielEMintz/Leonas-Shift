using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    [SerializeField] Sprite BlackDoorOpen;
    [SerializeField] Sprite BlackDoorClose;
    [SerializeField] Sprite WhiteDoorOpen;
    [SerializeField] Sprite WhiteDoorClose;
    [SerializeField] GameObject exitBond;
    public bool canBeOpened;
    public bool finishedLevel;
    public bool canPress;
    bool isopen = false;
    public bool toSwitch = false;
    bool isLight = true;
    SpriteRenderer sprite;
    GameManager gameManager;
    public KeyCode interactKey;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canBeOpened = true;
        canPress = false;
        finishedLevel = false;
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (canBeOpened && canPress)
        {
            if (Input.GetKeyDown(interactKey))
            {
                if (isopen)
                {
                    if (isLight)
                    {
                        sprite.sprite = WhiteDoorClose;
                        isopen = false;
                       
                    }
                    else
                    {
                        sprite.sprite = BlackDoorClose;
                        isopen = false;
                    }
                }
                else
                {
                    if (isLight)
                    {
                        sprite.sprite = WhiteDoorOpen;
                        isopen = true;
                    }
                    else
                    {
                        sprite.sprite = BlackDoorOpen;
                        isopen = true;
                        
                    }
                }

                exitBond.SetActive(false);
            }
        }
        if (toSwitch)
        {
            if (isopen)
            {
                if (isLight)
                {
                    sprite.sprite = BlackDoorOpen;
                    toSwitch = false;
                    isLight = false;
                }
                else
                {
                    sprite.sprite = WhiteDoorOpen;
                    toSwitch = false;
                    isLight = true;
                }
            }
            else
            {
                if (isLight)
                {
                    sprite.sprite = BlackDoorClose;
                    toSwitch = false;
                    isLight = false;
                }
                else
                {
                    sprite.sprite = WhiteDoorClose;
                    toSwitch = false;
                    isLight = true;
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            canBeOpened = true;
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
        canBeOpened = false;
        gameManager.MoveToNextScene();
    }

}
