using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
  
  public GameManager gameManager;

    // Update is called once per frame
    public Text textscore;
    void Update()
    {
        textscore.text = gameManager.GetComponent<OrderMechanic>().points.ToString();
    }
}
