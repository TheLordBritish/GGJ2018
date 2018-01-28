using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float speed; 

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        MovePlayer();
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
