using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStomp : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb;

    audioManager audioManager;
    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "head"){
            other.GetComponentInParent<Enemy>().Death();
            rb.velocity = new Vector2(rb.velocity.x, bounce);
            audioManager.PlaySFX(audioManager.stomp);
        }
    }
}
