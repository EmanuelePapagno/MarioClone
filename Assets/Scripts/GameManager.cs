using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isFirstManager;

    private void Awake()
    {
       
        DontDestroyOnLoad(transform.gameObject);
        GameManager[] gms = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gms.Length; i++)
        {

            if (gms[i].isFirstManager == true)
            {
                return;
            }
        }
            isFirstManager = true;
            for (int i = 0; i < gms.Length; i++)
            {

            if (gms[i].isFirstManager == false)
            {
                    Destroy(gms[i].gameObject);
            }
            }
        


       /* if (gm != null && this != gm)
        {
            DestroyImmediate(gm);
        }
        */
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
