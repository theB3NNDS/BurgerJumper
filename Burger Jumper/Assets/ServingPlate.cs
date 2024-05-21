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
            scriptOrderMechanic.AddIngredientToDish(other.gameObject.GetComponent<ball>().Identifier);
            Destroy(other.gameObject);
          Debug.Log(other.gameObject.GetComponent<ball>().Identifier);
        }
        
    }

    //typesOfIngredient = {"Patty", "Cheese", "Lettuce"};
}
