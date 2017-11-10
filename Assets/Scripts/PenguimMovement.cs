using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguimMovement : MonoBehaviour {

	public float maxSpeed = 400, acceleration = 10, shotCooldown = 1;
	public float angularSpeed = 100;

	private float linearSpeed = 0;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("a")) {
			this.transform.Rotate(new Vector3(0f, 0f, angularSpeed * Time.deltaTime));
		}
		if (Input.GetKey("d")) {
			this.transform.Rotate(new Vector3(0f, 0f, -angularSpeed * Time.deltaTime));
		}

		if (Input.GetKey("w")) {
			float xProjection = Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * acceleration;
			float yProjection = Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * acceleration;
			rigidBody.AddForce(new Vector2( xProjection, yProjection ), ForceMode2D.Force);
		}
	}
}
