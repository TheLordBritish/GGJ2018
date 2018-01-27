using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float distanceToActivate;
    private GameObject player;

	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");	
	}
	
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
                else if (hit.collider.CompareTag("TrapDoor"))
                {
                    AttemptExit(hit.collider.gameObject);
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

    private void AttemptExit(GameObject exit)
    {
        if (Vector3.Distance(player.transform.position, exit.transform.position) <= distanceToActivate)
        {
            // Get the generator and check if it's currently powered on.
            var generator = GameObject.FindGameObjectWithTag("Generator");
            var gm = generator.GetComponent<GeneratorManager>();

            if (gm.IsPoweredOn)
            {
                Debug.Log("Exiting level.");
                // TODO: Change scene.
            }
        }
    }
}
