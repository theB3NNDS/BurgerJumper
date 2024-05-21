using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    // Start is called before the first frame update
    OrderMechanic script;
    public GameManager gameManager;
    void Start()
    {
        script = gameManager.GetComponent<OrderMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
