using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*this code is to control the player, ie. the racecar*/

    //Private variables
    private Rigidbody playerRb;

    public float speed = 25.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    //out of bounds
    private float yBound = -5.0f;
    //PowerUp
    public GameObject powerup;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public int powerUpDuration = 1;

    //Projectiles
    Vector3 ImpulseVector = new Vector3(300.0f, 0.0f, 0.0f);

    //Audio and Particles
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
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

        //Out of bounds
        if (transform.position.y < yBound)
        {
            transform.position = new Vector3(0.1157171f, 0.8968f, 0.8233185f);
        }

        //Powerup Indicator
        powerupIndicator.transform.position = transform.position + new Vector3(0.01f, 2.8f, -0.07f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When car hits wall - audio and particles
        if (collision.gameObject.name == "Wall")
        {
            float bounce = 4050f;
            playerRb.AddForce(collision.contacts[0].normal * bounce);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        //when car hits obstacle - audio and particles
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            float bounce = 4050f;
            playerRb.AddForce(collision.contacts[0].normal * bounce);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //car enters spawn manager and powerup spawns
        if (other.gameObject.CompareTag("Spawn1"))
        {
            SpawnPowerup(transform.position + transform.forward * 15.0f);
        }

        //powerup speed boost and cooldown
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            speed = speed * 2;
            StartCoroutine(PowerupCooldownRoutine());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        speed = speed / 2;
    }

    //function to spawn powerups
    void SpawnPowerup(Vector3 spawnPosition)
    {
        spawnPosition.y = 2.0f; //setting y axis
        Instantiate(powerup, spawnPosition, powerup.gameObject.transform.rotation);
    }
}
