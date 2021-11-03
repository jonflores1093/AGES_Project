using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{

    public float speed = 5f;
    Vector3 startPos;
    private Rigidbody rb;
    [SerializeField] private Transform camera;

    void Start()
    {
    	rb = GetComponent<Rigidbody>();
        startPos = this.transform.position;
        Cursor.visible = false;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
       {
            Application.Quit();
        }
    }
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        //Makes it so that the player moves in the direction the camera is facing
        //Example: If the camera is facing north than the player should move north
        Vector3 cameraForward = camera.forward * movementVertical;
        Vector3 cameraRight = camera.right * movementHorizontal;
        Vector3 rawMovement = cameraForward + cameraRight;
        rawMovement.y = 0; //prevents the player from moving up.
        rawMovement = rawMovement.normalized; //Will keep the current vector. If it's set to 0 it will stay at zero
        rb.AddForce(rawMovement * speed);

    }
    

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reset")
        {
            this.transform.position = startPos;
        }
    }

 
}
