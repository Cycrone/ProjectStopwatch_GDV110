using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HUD : MonoBehaviour
{
    [SerializeField] public GameObject OutOfTimeUI;
    [SerializeField] public GameObject ItemUI;
    [SerializeField] public GameObject ItemUI2;
    [SerializeField] public GameObject ItemUI3;
    [SerializeField] public GameObject WinScreen;
    [SerializeField] public TMP_Text timerText;
    [SerializeField] public float timer = 500;
    public GameObject Item;
    public GameObject Item2;
    public GameObject Item3;
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
    public void ItemDisplay2()
    {
        ItemUI2.SetActive(true);
    }
    public void ItemDisplay3()
    {
        ItemUI3.SetActive(true);
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
        if (collider.gameObject.CompareTag("Item2"))
        {
            ItemDisplay2();
            Destroy(Item2);

        }
        if (collider.gameObject.CompareTag("Item3"))
        {
            ItemDisplay3();
            Destroy(Item3);

        }
        if (ItemUI.activeInHierarchy == true && collider.gameObject.CompareTag("Win"))
        {
            WinDisplay();
        }
        if (ItemUI.activeInHierarchy == true && ItemUI2.activeInHierarchy == true && collider.gameObject.CompareTag("Win2"))
        {
            WinDisplay();
        }
        if (ItemUI.activeInHierarchy == true && ItemUI2.activeInHierarchy == true  && ItemUI3.activeInHierarchy == true  && collider.gameObject.CompareTag("Win3"))
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
