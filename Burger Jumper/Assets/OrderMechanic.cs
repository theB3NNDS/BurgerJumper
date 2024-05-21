using System;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Random;
using UnityEngine;
using Unity.Burst.CompilerServices;

public class OrderMechanic : MonoBehaviour
{
    public String[] dishBeingPrepared = new String[5];
    public String[] Order = new String[5]; 
    private String[] typesOfIngredient = {"Patty", "Cheese", "Lettuce"};
    public int orderComplete = 10;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        CleanDishes();
        GenerateOrder();
        DisplayOrder(Order);
    }

    // Update is called once per frame
    void Update()
    {
         //DisplayOrder();
    }

    void GenerateOrder(){
        if(orderComplete < 5){
            for(int i = 0; i <= orderComplete; i++){
                Order[i] = typesOfIngredient[UnityEngine.Random.Range(0,3)];
                // Debug.Log(typesOfIngredient[UnityEngine.Random.Range(0,3)]);
            }
        } else{
            for(int i = 0; i <= 4; i++){
                Order[i] = typesOfIngredient[UnityEngine.Random.Range(0,3)];
                // Debug.Log(typesOfIngredient[UnityEngine.Random.Range(0,3)]);
            }
        }
    }

    void RingBell(){

        if(CompareOrderToDish(dishBeingPrepared, Order)){
            OrderIsCompleted();
        } else{
            points--;
        }
        CleanDishes();
        GenerateOrder();
    }

    bool CompareOrderToDish(String[] dishBeingPrepared, String[] Order){
        return  dishBeingPrepared == Order;
    }

    void OrderIsCompleted(){
        orderComplete++;
        points++;
    }

    void DisplayOrder(String[] order){
        Debug.Log("1st: " + order[0] + "\n2nd: " + order[1] + "\n3rd: " + order[2] + "\n4th: " + order[3] + "\n5th: " + order[4]);
    }
    public String DisplayOrderUI(String[] order){
        return ("1st: " + order[0] + "\n2nd: " + order[1] + "\n3rd: " + order[2] + "\n4th: " + order[3] + "\n5th: " + order[4]);
    }


    void CleanDishes(){
        for(int i = 0; i < 5; i++){
            dishBeingPrepared[i] = null;
        } 
        for(int i = 0; i < 5; i++){
            Order[i] = null;
        } 
    }

    public void AddIngredientToDish(string ingredient){
        for(int i = 0; dishBeingPrepared.Length > i; i++){
            if(dishBeingPrepared[i] != null){
                continue;
            } else
            dishBeingPrepared.SetValue(ingredient, i);
            break;

        }
        

    }

   

    
}
