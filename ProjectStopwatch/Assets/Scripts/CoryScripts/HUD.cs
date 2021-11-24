using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] public GameObject OutOfTimeUI;
    [SerializeField] public GameObject ItemUI;
    [SerializeField] public GameObject WinScreen;
    [SerializeField] public TMP_Text timerText;
    [SerializeField] public float timer = 500;
    public GameObject Item;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerHUD();
        DisplayTime(timer);
    }

    //Timer display
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ItemDisplay()
    {
        ItemUI.SetActive(true);
    }

    public void WinDisplay()
    {
        WinScreen.SetActive(true);
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            ItemDisplay();
            Destroy(Item);

        }
        if (ItemUI.activeInHierarchy == true && collider.gameObject.CompareTag("Win"))
        {
            WinDisplay();
        }
    }

    //HUD timer
    void TimerHUD()
    { 
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                
                timer -= Time.deltaTime;
            }
            else
            {
                Time.timeScale = 0f;
                OutOfTimeUI.SetActive(true);
                timer = 0f;
                timerIsRunning = false;
            }
            
        }

    }

}
