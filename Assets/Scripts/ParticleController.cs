using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem system;

    void Awake()
    {
        system = GetComponent<ParticleSystem>();
    }
	
	void Update ()
    {
	    if (!system.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
