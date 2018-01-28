using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private HealthSystem health;

    public List<GameObject> deathParticles;

    public float speed; 

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<HealthSystem>();
    }

	// Update is called once per frame
	void Update() 
    {
        if (!health.IsDead())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }

            MovePlayer();
        }
        else
        {
            foreach (GameObject go in deathParticles)
            {
                Instantiate(go, transform.position, transform.rotation);
            }

            ScreenTransitionImageEffect transition = Camera.main.GetComponent<ScreenTransitionImageEffect>();
            transition.ChangeScene = true;
            transition.sceneName = "DeathScene";

            GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in objects)
            {
                go.SetActive(false);
            }

            gameObject.SetActive(false);
        }
	}

    private void MovePlayer()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }

        if (Input.GetKey((KeyCode.D)))
        {
            movement += Vector3.right;
        }

        if (Input.GetKey((KeyCode.A)))
        {
            movement += Vector3.left;
        }

        transform.Translate(movement * speed * Time.deltaTime);
        animator.SetBool("isMoving", movement != Vector3.zero);
    }
}
