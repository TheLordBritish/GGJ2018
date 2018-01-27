using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public GameObject spine;
    public float speed; 

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update() 
    {
        MovePlayer();
	}

    private void MovePlayer()
    {
        bool isMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), Time.deltaTime * 15.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.forward), Time.deltaTime * 15.0f);
        }

        if (Input.GetKey((KeyCode.D)))
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), Time.deltaTime * 15.0f);
        }

        if (Input.GetKey((KeyCode.A)))
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), Time.deltaTime * 15.0f);
        }

        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        animator.SetBool("isMoving", isMoving);
    }
}
