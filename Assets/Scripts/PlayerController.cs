using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 10f;
    public float walkSpeed = 7f;
    public float currentSpeed;
    public float rotationSpeed = 10f;
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        currentSpeed = walkSpeed;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
        }
    }
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontal, 0, vertical);
        Vector3 movementDir = movementInput.normalized;
        if (movementDir != Vector3.zero)
        {
            Quaternion desiredRot = Quaternion.LookRotation(movementDir, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, desiredRot, rotationSpeed * Time.fixedDeltaTime));
        }
        rb.MovePosition(transform.position + movementDir * currentSpeed * Time.fixedDeltaTime);
    }
}
