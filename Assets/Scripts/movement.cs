using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
	public float rotationSpeed = 10.0F;
	public float jumpHeight = 3.0F;

	private bool isFalling = false;

	private Rigidbody rigid;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		//Handles the movement of the ball
		float xMove = Input.GetAxis("Horizontal") * rotationSpeed;
		float zMove = Input.GetAxis("Vertical") * rotationSpeed;
		xMove *= Time.deltaTime;
		zMove *= Time.deltaTime;
		if (rigid != null)
		{
			//Apply movement
			Vector3 xDirection = new Vector3(xMove, 0.0F, 0.0F);
			Vector3 zDirection = new Vector3(0.0F,0.0F ,zMove);

			//Uses the object's mass to apply instant impulse force.
			rigid.AddForce(xDirection, ForceMode.Impulse);
			rigid.AddForce(zDirection, ForceMode.Impulse);

			//Handles the jump function
			if (UpKey() && !isFalling)
			{
				
				rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
			}
		}
	}

	public void OnCollisionStay(Collision col)
	{ 
		isFalling = false;
	}

	public void OnCollisionExit()
	{
		isFalling = true;
	}

	private bool UpKey()
	{
		return (Input.GetKeyDown(KeyCode.Space));
	}
}
