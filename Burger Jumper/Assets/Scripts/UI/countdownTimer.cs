using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    [SerializeField] TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void IncreaseTime()
    {
        currentTime += 30f;
    }

    public void DecreaseTime()
    {
        currentTime -= 10f;
    }
}
