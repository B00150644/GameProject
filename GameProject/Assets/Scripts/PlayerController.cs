using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
/*this code is to control the player, ie. the racecar*/
    //Private variables
    private float speed = 25.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    
    void Start()
    {
        
    }

    void Update()
    {
        //Player Input to move car 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Turn Car
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);        
    }
}
