using UnityEngine;
using System;
public enum WalkDir
{
    forward, backward, left, right
}

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed = 10f;
    public float walkSpeed = 7f;
    public float currentSpeed;

    [Header("Refrences")]
    public Animator anim;
    public GameObject playerMesh;
    public SpriteRenderer head;
    public Sprite headFront, headBack;
    public static PlayerController i;
    [HideInInspector]
    public Rigidbody2D rb;
    public void Start()
    {
        if (CameraController.i != null)
            CameraController.i.playerTransform = transform;
        i = this;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
        playerMesh.transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movementInput = new Vector2(horizontal, vertical);
        Vector2 movementDir = movementInput.normalized;
        if (movementDir != Vector2.zero)
        {
            if (movementDir.y > 0)
            {
                head.sprite = headBack;
            }
            else
            {
                head.sprite = headFront;
            }
        }
        anim.SetBool("isMoving", movementDir != Vector2.zero);
        rb.MovePosition(rb.position + movementDir * currentSpeed * Time.fixedDeltaTime);
    }
}
