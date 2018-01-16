using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasePlayer : Agent {

    public Vector3 checkpoint;

    private static int PlayerCount = 0;

    private Transform myTransform = null;

    float Timer = 0f;


    private void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        if (rigidbody == null) {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.freezeRotation = true;
        }

        PlayerCount = PlayerCount + 1;
        myTransform = gameObject.GetComponent<Transform>();
        Debug.Log("Player count: " + PlayerCount);

    }

    private void Update() {

        

        if (Name == "Mario") {
            // Movimento sinistra P1
            if (Input.GetKey(KeyCode.A)) {
                myTransform.position = myTransform.position + new Vector3(-MovementSpeed, 0, 0);
            }
            // Movimento destra P1
            if (Input.GetKey(KeyCode.D)) {
                myTransform.position = myTransform.position + new Vector3(MovementSpeed, 0, 0);
            }
            // Salto P1
            if (Input.GetKeyDown(KeyCode.W) == true && JumpCount < 2) {
                rigidbody.AddForce(new Vector3(0, JumpForce, 0));
                JumpCount = JumpCount + 1;
            }



        } else if (Name == "Luigi") {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                myTransform.position = myTransform.position + new Vector3(-MovementSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                myTransform.position = myTransform.position + new Vector3(MovementSpeed, 0, 0);
            }
            // Salto P2
            if (Input.GetKeyDown(KeyCode.UpArrow) == true && JumpCount < 3) {
                rigidbody.AddForce(new Vector3(0, JumpForce, 0));
                JumpCount = JumpCount + 1;
            
        }
        }

        if (IsAlive == false) {
            Timer = Timer + Time.deltaTime;
            Delay();
        }
    }

    /// <summary>
    /// Viene chiamata quando l'oggetto entra in collisione con un altro oggetto.
    /// </summary>
    /// <param name="collision"></param>


    
    private void OnCollisionEnter(Collision collision) {
    JumpCount = 0;

    if (collision.collider.gameObject.tag == "Respawn") {
        Kill();
    }

    if (collision.collider.gameObject.tag == "Enemy")
    {
        Damage(1);
    }

   if (collision.collider.gameObject.tag == "WeakPoint") {
        Destroy(collision.transform.parent.gameObject);

    }


    if (collision.collider.gameObject.tag == "Heal")
    {
        Damage(-1);
        Destroy(collision.gameObject);
    }

    if (collision.collider.gameObject.tag == "Finish")
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            respawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    /* private void OnTriggerEnter(Collider other)
    {
        JumpCount = 0;

        if (other.gameObject.tag == "Respawn")
        {
            Kill();
        }

        if (other.gameObject.tag == "Enemy")
        {
            Damage(1);
        }

        if (other.gameObject.tag == "WeakPoint")
        {
            Destroy(other.transform.parent.gameObject);

        }


        if (other.gameObject.tag == "Heal")
        {
            Damage(-1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    */


    public static void PrintLog() {
        Debug.Log("Sono una funzione statica");
    }


    private void Delay() {
        if (Timer >= RespawnDelay)
            Respawn();
    }

    void Respawn() {
        transform.position = respawnPosition;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        Reborn();
    }

    /// <summary>
    /// Resetta tutte le impostazione di base del personaggio.
    /// </summary>
    void Reborn() {
        Life = initialLife;
        IsAlive = true;
        Timer = 0;
    }

}
