using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    //[SerializeField]
    public float plat_velocity = 0.2f;

    public Vector2 point_a;
    public Vector2 point_b;

    //[SerializeField]
    public Transform childTransform;

    public Transform transformB;

    private Vector2 next_position;

    private bool moving;

    private void OnCollisionEnter2D(Collision2D collision_plat)
    {
        if (collision_plat.gameObject.tag.Contains("Player"))
        {
            moving = true;
            collision_plat.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision_plat)
    {
        if (collision_plat.gameObject.tag.Contains("Player"))
        {
            moving = false;
            collision_plat.collider.transform.SetParent(null);
        }
    }

    private void ChangeDestination()
    {
        next_position = next_position != point_a ? point_a : point_b;
    }

    void Start()
    {
        point_a = childTransform.localPosition;
        point_b = transformB.localPosition;
        next_position = point_b;
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            childTransform.localPosition = Vector2.MoveTowards(childTransform.localPosition, next_position, plat_velocity * Time.deltaTime);
            if (Vector3.Distance(childTransform.localPosition, next_position) <= 0.1)
            {
                ChangeDestination();
            }
        }
    }
}
/*
    void Update()
    {

    }
*/