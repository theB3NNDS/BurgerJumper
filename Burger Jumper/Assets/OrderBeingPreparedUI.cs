using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderBeingPreparedUI : MonoBehaviour
{
    public GameManager gameManager;
    public Text text;
    OrderMechanic scriptOrderMechanic;

    
    // Start is called before the first frame update
    void Start(){
        scriptOrderMechanic = gameManager.GetComponent<OrderMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = scriptOrderMechanic.DisplayOrderUI(scriptOrderMechanic.dishBeingPrepared);
    }
}
