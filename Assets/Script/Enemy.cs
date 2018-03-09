﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    private Transform[] positions;
    private int index=0;


	// Use this for initialization
	void Start () {
        positions = WayPoints.positions;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        //Debug.Log("Time" + Time.deltaTime);
    }

    void Move()
    {
        if (index > positions.Length - 1)
        {
            return;
        }
        transform.Translate((positions[index].position-transform.position).normalized*Time.deltaTime*speed);
        if(Vector3.Distance(positions[index].position,transform.position) < 0.2f)
        {
            index++;
        }
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }

     void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

}
