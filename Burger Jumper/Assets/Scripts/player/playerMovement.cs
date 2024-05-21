using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public InputActionReference move;
    public InputActionReference jump;

    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float jumpForce = 30f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x:moveDirection.x * moveSpeed, y:rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnEnable()
    {
        jump.action.performed += PerformJump;
    }

    private void OnDisable()
    {
        jump.action.performed -= PerformJump;
    }

    private void PerformJump (InputAction.CallbackContext obj)
    {
        
        Jump();
    }
}
