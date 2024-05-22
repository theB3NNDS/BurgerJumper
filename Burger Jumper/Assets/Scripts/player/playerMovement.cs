using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public InputActionReference move;
    public InputActionReference jump;

    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float jumpForce = 30f;

    [SerializeField] int playerHealth = 3;
    [SerializeField] TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthText.text = playerHealth.ToString();
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
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "enemy"){
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        playerHealth -= 1;
        healthText.text = playerHealth.ToString();

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
