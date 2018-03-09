using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

    public float speed = 20;
    public float mouseSpeed = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");  //a d
        float v = Input.GetAxis("Vertical");    //w s
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        //print("mouse:");
       // Debug.Log(mouse);
        //print("h:");
        //Debug.Log(h);
        transform.Translate(new Vector3(h * speed, mouse* mouseSpeed, v * speed) *Time.deltaTime, Space.World);
	}

    
}
