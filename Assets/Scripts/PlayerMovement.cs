using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
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
       //  RotatePlayer();
        MovePlayer();
	}

    private void RotatePlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 dir = mousePos - playerPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
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
