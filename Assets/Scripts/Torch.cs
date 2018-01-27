using UnityEngine;

public class Torch : MonoBehaviour {

    [SerializeField]
    private float torchRadius;

	// Use this for initialization
	void Start()
    {
	    	
	}
	
	// Update is called once per frame
	void Update()
    {

	}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("Monster in torch-light.");
        }
    }
}
