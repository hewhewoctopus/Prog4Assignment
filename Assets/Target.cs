using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    // Speed at which the target moves
    public float speed = 5f;

    // Reference to the player object
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the target towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    // OnTriggerEnter is called when the target collides with another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Get the Player component and call its KillPlayer method
            other.GetComponent<Player>().KillPlayer();
        }
    }
}
