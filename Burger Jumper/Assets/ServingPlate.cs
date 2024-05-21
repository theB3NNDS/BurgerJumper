using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingPlate : MonoBehaviour
{
    public GameManager gameManager;
    OrderMechanic scriptOrderMechanic;

    
    // Start is called before the first frame update
    void Start(){
        scriptOrderMechanic = gameManager.GetComponent<OrderMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "TrajectoryBall"){
           if( other.gameObject.transform.parent.name.StartsWith("Lettuce Variant") ){
                scriptOrderMechanic.AddIngredientToDish("Lettuce");
           } else if(other.gameObject.transform.parent.name.StartsWith("Patty")){
                scriptOrderMechanic.AddIngredientToDish("Patty");
           } else{
            scriptOrderMechanic.AddIngredientToDish("Cheese");
           }
                Destroy(other.gameObject);
        }
        Debug.Log("Plate collided with " + other.gameObject.transform.parent.name);
    }
}
