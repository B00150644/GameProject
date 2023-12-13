using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    //Destroy Object on collisio with ball
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Obstacle is hit by " + collision.gameObject.name);          
            Destroy(gameObject);

        }
    }
}
