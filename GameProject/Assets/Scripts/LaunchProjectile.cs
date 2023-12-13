using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    //Launching point
    public Transform ballSpawnPoint; 
    
    //Projectile ball
    public GameObject ballPrefab;

    //ball speed
    public float ballSpeed = 50f;

    //one at a time
    private float cooldown = 1;                           


    // Update is called once per frame
    void Update()
    {
        //launching projectiles
        if (Input.GetKey(KeyCode.Space) && cooldown <= 0)
        {
            var ball = Instantiate(ballPrefab, transform.position, ballPrefab.transform.rotation);
             ball.GetComponent<Rigidbody>().velocity = ballSpawnPoint.forward * ballSpeed;
            cooldown = 1;
        }
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        } 

    }

   

}
