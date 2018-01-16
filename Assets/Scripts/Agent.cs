using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    /// <summary>
    /// Nome dell'agent.
    /// </summary>
    public string Name;
    public int Life;
    /// <summary>
    /// Salva il valore iniziale della vita.
    /// </summary>
    protected int initialLife;
    public bool IsAlive = true;
    /// <summary>
    /// Velocità di movimento (maggiore è il valore, maggiore sarà la velocità di spostamento)
    /// </summary>
    public float MovementSpeed;
    /// <summary>
    /// Forza con coi avviene la spinta verso l'alto.
    /// </summary>
    public float JumpForce = 10;
    /// <summary>
    /// Identifica se il personaggio sta attualmenmte saltando (se true sta saltando).
    /// </summary>
    public int JumpCount = 0;

    public float RespawnDelay = 1;

    protected Vector3 respawnPosition;

    public Rigidbody rigidbody = null;

    private void Awake() {
        initialLife = Life;
        respawnPosition = transform.position;
    }

    /// <summary>
    /// Toglie una unità di salute a questo oggetto.
    /// </summary>
    public void Damage(int damageAmount)
    {
        Debug.Log("Ho subito un danno " + Name);
        Life = Life - damageAmount;
        
        if (Life <= 0)
        {
            IsAlive = false;
            if (gameObject.GetComponent<MeshRenderer>() != null) {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

        }
    }

    /// <summary>
    /// Uccide il personaggio togliendo tutta la vita.
    /// </summary>
    public void Kill() {
        Damage(Life);
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPosition = newRespawnPoint;
    }

   /* public void Die()
    {
        Destroy(gameObject);
    }
    */
}
