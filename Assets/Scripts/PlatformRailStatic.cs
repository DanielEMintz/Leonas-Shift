using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRailStatic : MonoBehaviour
{
	public float speed = 2;
	public Transform pointA;
	public Transform pointB;
	public bool isMoving = true;

	GameObject player = null;


	Vector3 dest; // destination


	void Start(){
		dest = pointA.position;
	}

	void FixedUpdate(){
		Vector3 previousPos = transform.position;
		transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.fixedDeltaTime);

		if(player != null){
			// the player will follow the same path as the platform
			player.transform.position += transform.position - previousPos;
		}

		if(transform.position == dest){
			ChangeDirection();
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag.Contains("Player")){
			player = other.gameObject;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag.Contains("Player")){
			player = null;
		}
	}

	void ChangeDirection(){
		if(dest == pointA.position) dest = pointB.position;
		else dest = pointA.position;
	}
}
