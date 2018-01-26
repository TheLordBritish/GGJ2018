using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour {

    List<GameObject> lights;

    private bool isCharged;
    private float chargeLevel;

	// Use this for initialization
	void Start () 
    {
        lights = new List<GameObject>(GameObject.FindGameObjectsWithTag("light"));

        isCharged = true;
        chargeLevel = 10.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        chargeLevel -= Time.deltaTime;
        TurnOffLights();
	}

    public void TurnOffLights()
    {
        if (chargeLevel <= 0.0f)
        {
            isCharged = false;

            foreach (GameObject l in lights)
            {
                // l.GetComponent(light code here);
            }
        }
    }
}
