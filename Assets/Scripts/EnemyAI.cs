﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform myTransform;

    public int moveSpeed;

    public GameObject EnemyProjectile;

    float spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = Random.Range(-1.80f, 1.80f);
        myTransform = transform;
        myTransform.position = new Vector3(spawnLocation, 5, -5);
    }

    // Update is called once per frame
    void Update()
    {
        float randomMoving = Random.Range(-5.0f, 5.0f);

        myTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
        if(myTransform.position.y < -5.0f)
        {
            //change current speed
            //change the x axis
            spawnLocation = Random.Range(-1.80f, 1.80f);
            myTransform.position = new Vector3(spawnLocation, 5, -5);
            //Destroy(gameObject);
        }
    }
}
