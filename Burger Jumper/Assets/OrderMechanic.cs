using System;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Random;
using UnityEngine;
using Unity.Burst.CompilerServices;

public class OrderMechanic : MonoBehaviour
{
    public static OrderMechanic instance;
    public String[] dishBeingPrepared = new String[5];
    public String[] Order = new String[5]; 
    private String[] typesOfIngredient = {"Patty", "Cheese", "Lettuce"};
    public int orderComplete = 10;
    public int points = 0;
    public GameObject[] burgers;

    public countdownTimer timing;
    
    // Start is called before the first frame update
    void Start()
    {
        CleanDishes();
        GenerateOrder();
        DisplayOrder(Order);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(CompareOrderToDish(dishBeingPrepared, Order)){
            foreach (GameObject burger in burgers)
            {
                burger.SetActive(true);
            }

        }
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

    public void RingBell(){


   
        //compare Order and OrderBeingPrepared
        if(CompareOrderToDish(dishBeingPrepared, Order)){
            GameObject[] burgers = GameObject.FindGameObjectsWithTag("burger");
           
            OrderIsCompleted();
             foreach (GameObject burger in burgers)
            {
                burger.SetActive(false);
            }

        } else{
            --points;
            timing.DecreaseTime();
            Debug.Log("Order" +DisplayOrderUI(Order));
            Debug.Log("Dish being prepared" + DisplayOrderUI(dishBeingPrepared));

        }
        CleanDishes();
        GenerateOrder();

        //If Order matches OrderBeingPrepared 
        // -Score 1 points
        // -Increment Dishcompleted ++
        //Else
        // -deduct points
        
        //Refresh
        
    }

public bool CompareOrderToDish(string[] dishBeingPrepared, string[] order)
{
  // Check for invalid array sizes
  if (dishBeingPrepared == null || order == null || dishBeingPrepared.Length != 5 || order.Length != 5)
  {
    return false; // Arrays are not valid (null or different size)
  }

  // Compare elements and order
  for (int i = 0; i < dishBeingPrepared.Length; i++)
  {
    if (dishBeingPrepared[i] != order[i])
    {
      return false; // Elements at the same index are not equal
    }
  }

  return true; // All elements are equal and in the same order
}
    public void OrderIsCompleted(){
        orderComplete++;
        points++;
        timing.IncreaseTime();
    }

    void DisplayOrder(String[] order){
        Debug.Log("1st: " + order[0] + "\n2nd: " + order[1] + "\n3rd: " + order[2] + "\n4th: " + order[3] + "\n5th: " + order[4]);
    }
    public String DisplayOrderUI(String[] order){
        return ("1st: " + order[0] + "\n2nd: " + order[1] + "\n3rd: " + order[2] + "\n4th: " + order[3] + "\n5th: " + order[4]);
    }


    public void CleanDishes(){
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
