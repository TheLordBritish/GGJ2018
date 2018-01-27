using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    private List<GameObject> lights;

    [SerializeField]
    private float chargeAmount;

    private float currentCharge;

	// Use this for initialization
	void Start() 
    {
        lights = new List<GameObject>(GameObject.FindGameObjectsWithTag("Light"));
        currentCharge = chargeAmount * 0.5f;
	}
	
	// Update is called once per frame
	void Update()
    {
        currentCharge -= Time.deltaTime;
        TurnOffLights();
	}

    private void TurnOffLights()
    {
        if (currentCharge <= 0.0f)
        {
            lights.ForEach(go => go.SetActive(false));
        }
    }

    public void TurnOnLights()
    {
        currentCharge = chargeAmount;
        lights.ForEach(go => go.SetActive(true));
    }
}
