using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = Object.FindObjectOfType<PenguimMovement>().transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
	}
}
