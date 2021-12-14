using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
    
    public float speed = 10f;
    Vector3 startPos;
    private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;
    
    
    
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        startPos = gameObject.transform.position;
        

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        
    }
    /// <summary>
    /// Allows the player to move using WASD in the direction that the camera is facing
    /// </summary>
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        //Makes it so that the player moves in the direction the camera is facing
        //Example: If the camera is facing north than the player should move north
        Vector3 cameraForward = cameraTransform.forward * movementVertical;
        Vector3 cameraRight = cameraTransform.right * movementHorizontal;
        Vector3 rawMovement = cameraForward + cameraRight;
        rawMovement.y = 0; //prevents the player from moving up.
        rawMovement = rawMovement.normalized; //Will keep the current vector. If it's set to 0 it will stay at zero
        rb.AddForce(rawMovement * speed);

    }
    

    
    /// <summary>
    /// Makes it so that the scene loads once the play collides with an empty game object.
    /// The game objects have tags that reference which scene needs to be loaded next.
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "Reset")
        {
            gameObject.transform.position = startPos;
        }

        if (other.tag == "Ending")
        {
            SceneManager.LoadScene("Credits");
        }    
    }

  
}
