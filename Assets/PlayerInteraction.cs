using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField]
    private float distanceToActivate;
    private GameObject player;

	// Use this for initialization
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Generator"))
                {
                    AttemptGenerateActivation(hit.collider.gameObject);
                }
            }
        }
	}

    private void AttemptGenerateActivation(GameObject generator)
    {
        if (Vector3.Distance(player.transform.position, generator.transform.position) <= distanceToActivate)
        {
            Debug.Log("Activating generator.");
            generator.GetComponent<GeneratorManager>().TurnOnLights();
        }
    }
}
