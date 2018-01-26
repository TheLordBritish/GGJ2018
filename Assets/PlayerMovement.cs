using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log(("forward")); 
            transform.Translate(Vector3.forward * Time.deltaTime * speed); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(("backwards"));
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }

        if(Input.GetKey((KeyCode.D)))
        {
            Debug.Log(("forward"));
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey((KeyCode.A)))
        {
            Debug.Log(("forward"));
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
	}
}
