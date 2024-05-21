using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class OrderTicket : MonoBehaviour
{
     public GameManager gm;
     public GameObject Ingredient1;
     public GameObject Ingredient2;
     public GameObject Ingredient3;
     public GameObject Ingredient4;
     public GameObject Ingredient5;
     public Sprite[] icons =  new Sprite[5];
     //0. Cheese
     //1. Patty
     //2. Lettuce
     //3. Correct
     //4. Wrong



     String[] Order; 
     String[] dishBeingPrepared;




    // Start is called before the first frame update
    void Start()
    {
        OrderMechanic gmScript = gm.GetComponent<OrderMechanic>();
        String[] Order = gmScript.Order;
        dishBeingPrepared =gmScript.dishBeingPrepared;
        
      
    }

    // Update is called once per frame
    void Update()
    {
        Order = gm.GetComponent<OrderMechanic>().Order;
        // Ingredient1.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = null;// icons[1];
        // Debug.Log(Ingredient1.transform.GetChild(0).name);
        DisplayOrder();
      
        
    }

    Sprite GetIngredientSprite (String ingredientFromOrder){
        //returns the finds the correct sprite
        if(ingredientFromOrder == null){
            return null;
        } else if(ingredientFromOrder == "Cheese"){
            return icons[0]; //returns Cheese icon
        } else if(ingredientFromOrder == "Patty"){
            return icons[1]; //returns Patty icon
        } else{
            return icons[2]; //returns Lettuce
        }
    }

    void SetIngredientSpriteToIngredient(GameObject ingredient, String orderIndex){
        ingredient.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GetIngredientSprite(orderIndex); 

    }

    void DisplayOrder(){
        SetIngredientSpriteToIngredient(Ingredient1, Order[0]);
        SetIngredientSpriteToIngredient(Ingredient2, Order[1]);
        SetIngredientSpriteToIngredient(Ingredient3, Order[2]);
        SetIngredientSpriteToIngredient(Ingredient4, Order[3]);
        SetIngredientSpriteToIngredient(Ingredient5, Order[4]);
    }





    
}
