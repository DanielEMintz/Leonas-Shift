using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawn : MonoBehaviour
{
    [SerializeField] GameObject player;


    public Transform spawnTransform;
    void Start()
    {
         spawnTransform = GetComponent<CapsuleCollider2D>().transform;
    }

    void Update()
    {
        
    }
}
