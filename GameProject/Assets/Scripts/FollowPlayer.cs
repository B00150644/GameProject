using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /*this code is to make the main camera to follow the player, ie. racecar as it drives the track*/
    public GameObject player;
    private Vector3 offset = new Vector3(0, 9, -15);
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
