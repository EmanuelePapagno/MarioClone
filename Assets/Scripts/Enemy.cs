using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent {

    public Vector3 ArrivePoint;
    private Vector3 destination;
    private bool goToRight;
    private bool goUp;
    public bool isHorizontal = true;

    private void Start() {
        transform.position = respawnPosition;
        // Variabili di movimento
        goToRight = true;
        destination = ArrivePoint;
    }
    private void Update() {
        Movement();    

    }

   


    public void Movement() {
        /*
        if (isHorizontal == true)
        { 
            if (transform.position.x < destination.x)
            {

            }
        }
        */
        if (transform.position.x < destination.x) {
            // sono a sx dell'obbiettivo
            if (goToRight == false) {
                goToRight = true;
                destination = ArrivePoint;
            }
        } else {
            // sono a dx dell'obbiettivo
            if (goToRight == true) {
                goToRight = false;
                destination = respawnPosition;
            }
        }

        if (goToRight == true) {
            // vado a dx
            transform.Translate(Vector3.right * Time.deltaTime);
        } else {
            // varo a sx
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        
    }

}

