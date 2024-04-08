using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyAfterSeconds = 3f;
    public float destroyTimer;
    public RandomSpawner randomSpawner { get; private set; }

    private void Start()
    {
        destroyTimer = 0f;
        randomSpawner = FindObjectOfType<RandomSpawner>();
    }

    private void Update()
    {
        destroyTimer += Time.deltaTime;

        //Check if the bullet should be destroyed based on time 
        if(destroyTimer >= destroyAfterSeconds)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"));
        {
            //Destroy the enemy 
            Destroy(collision.gameObject);
            randomSpawner.EnemySpawn();
        }

        // Object the bullet on collision with any object
        Destroy(gameObject);
    }
}