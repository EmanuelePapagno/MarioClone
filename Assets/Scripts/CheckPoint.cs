using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public Transform Spawnposition;

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
            //Spawnposition.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            BasePlayer playerscript = other.GetComponent<BasePlayer>();
            playerscript.SetRespawnPoint(transform.position);
        }
    }


}


