using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OrderDescription : MonoBehaviour
{
    public GameManager gm;
    public Text orderDescription;

   
    
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        orderDescription.text =         "ingredient 1: " + gm.GetComponent<OrderMechanic>().Order[0] +  "\n" + 
        "ingredient 2: " + gm.GetComponent<OrderMechanic>().Order[1] +  "\n" +
        "ingredient 3: " + gm.GetComponent<OrderMechanic>().Order[2] +  "\n" +
        "ingredient 4: " + gm.GetComponent<OrderMechanic>().Order[3] +  "\n" +
        "ingredient 5: " + gm.GetComponent<OrderMechanic>().Order[4] +  "\n" ;
         }
}
