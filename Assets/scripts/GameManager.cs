using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeValue = 90;//start time
    public Text timeText;

    public GameObject completeLevelUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime; //minus the time from the last fram/last update fun

        }
        else //in the last update before this else the timer will be less than 0 by a ery small amount
        {
           // timeUp();
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay <0) //so that it does't display anything less than 0
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay >0) // so there's no bonus second
        {
            timeToDisplay += 1;
        }
        //calculate the time in minuts and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void timeUp()
    {
        completeLevelUI.SetActive(true);
    }
}