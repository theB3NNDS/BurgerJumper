using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPlate : MonoBehaviour
{
    GameObject[] dish = new GameObject[6];
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Big Plate: " + other.gameObject.name);
    }
}
