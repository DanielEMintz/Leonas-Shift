using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public SoundManagerScript sound;
    public float damageFromSpikes = 10; // HP reduced when colliding with "Spikes" tagged objects
    bool didHit = false;

    [SerializeField] Sprite Dark;
    [SerializeField] Sprite lightS;

    SpriteRenderer sprite;

    float timer = 0;
    public bool isLight = true;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!didHit && collision.gameObject.CompareTag("Player"))
    //    {
    //    }
    //}

    private void Update()
    {

        if (didHit)
        {
            if ((timer += Time.deltaTime) > 1f)
            {
                didHit = false;
                timer = 0;
            }
        }

        if (isLight)
        {
            sprite.sprite = lightS;
        }
        else
        {
            sprite.sprite = Dark;
        }
    }




}
