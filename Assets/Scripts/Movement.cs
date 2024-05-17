using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    //variables for Movement
    [SerializeField]float thrust = 100000f;
    [SerializeField] float rotationThrust = 25f;

    Rigidbody rb; 

    void Start() // Start is called before the first frame update
    {
        rb = GetComponent<Rigidbody>();

    }


    void Update() // Update is called once per frame
    {
        ProcessThrustUp();
        ProcessRotate();
    }

    void ProcessThrustUp() //thrust up on space press 
    {
        
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime); 
            
        }
    }

    void ProcessRotate() //rotate left or right using A or D 
    {
       if (Input.GetKey(KeyCode.A))
        {
          transform.Rotate(1,0,0 * rotationThrust * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-1, 0, 0 * rotationThrust * Time.deltaTime);
        }

    }

    void applyroation(float rotationThisFrame) 
    {
        rb.freezeRotation = false; // freezing rotation 
        transform.Rotate(Vector3.forward  * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = true;

    }
}
