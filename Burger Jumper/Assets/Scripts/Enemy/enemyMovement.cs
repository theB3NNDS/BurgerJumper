using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private int flip = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * flip, 0);
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("Enemy colllided with: " + other);
        if (other.tag == "Edge"){
            // Debug.Log("Switch ");
            flip *= -1;
        }
        
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject.tag == "Player") {
    //         Destroy(gameObject);
    //     }
    // }

    

    
}
