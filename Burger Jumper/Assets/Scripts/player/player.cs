using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (gameObject.transform.position.y < lowerLeft.y)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            gameObject.GetComponent<playerMovement>().TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "enemy"){
            // Debug.Log("collided with enemy");
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void Death(){
        Destroy(gameObject);
    }
}
