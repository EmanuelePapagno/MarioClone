﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform target;


	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}
}
