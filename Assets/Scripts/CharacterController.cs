using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private float moveInput;
    private float jumpInput;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool jump;
    private Vector3 charPos;
    private Camera camera;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Vertical");

        if(isGrounded && jumpInput > 0)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            jump = false;
        }
        charPos = transform.position;
    }
    private void LateUpdate()
    {
        if (camera != null)
            camera.transform.position = new Vector3(charPos.x, charPos.y, -10);
        else 
            Debug.Log("Kamera Tanımlı Değil.");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Plane"))
        {
            isGrounded = true;
        }
    }
}
