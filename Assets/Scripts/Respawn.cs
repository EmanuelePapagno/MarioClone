﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform Spawnposition;
    public GameObject player;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = Spawnposition.position;
        }
    }


}



