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
        RotatePlayer();
        MovePlayer();
	}

    private void RotatePlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 dir = mousePos - playerPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log(("forward"));
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(("backwards"));
            transform.position = Vector3.MoveTowards(transform.position, transform.position + -Vector3.forward, Time.deltaTime * speed);
        }

        if (Input.GetKey((KeyCode.D)))
        {
            Debug.Log(("forward"));
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, Time.deltaTime * speed);
        }

        if (Input.GetKey((KeyCode.A)))
        {
            Debug.Log(("forward"));
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, Time.deltaTime * speed);
        }
    }
}
