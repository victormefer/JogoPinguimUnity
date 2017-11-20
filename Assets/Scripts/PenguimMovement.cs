using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguimMovement : MonoBehaviour {

	public float maxSpeed = 500, acceleration = 10, shotCooldown = 1;
	public float angularSpeed = 150;

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

		if (Input.GetKey("w")) 
		{
			// float xProjection = Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * acceleration;
			// float yProjection = Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * acceleration;
			// rigidBody.AddForce(new Vector2( xProjection, yProjection ), ForceMode2D.Force);
			if (linearSpeed < maxSpeed * Time.deltaTime)
				linearSpeed += acceleration * Time.deltaTime;
			else
				linearSpeed = maxSpeed * Time.deltaTime;

			float xProjection = Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * linearSpeed;
			float yProjection = Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * linearSpeed;
			rigidBody.velocity = new Vector2(xProjection, yProjection);
		}
		else
		{
			if (linearSpeed > 0f) {
				linearSpeed -= acceleration * Time.deltaTime;
				if (linearSpeed <= 0f) linearSpeed = 0f;
			}

			float xProjection = Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * linearSpeed;
			float yProjection = Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * linearSpeed;
			rigidBody.velocity = new Vector2(xProjection, yProjection);
		}
	}
}
