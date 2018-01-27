using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float zoomDistance;
    private GameObject player;

	// Use this for initialization
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.position = player.transform.position - transform.forward * zoomDistance;	
	}
}
