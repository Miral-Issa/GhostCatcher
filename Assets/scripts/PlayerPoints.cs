using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPoints : MonoBehaviour
{
    public static int totalPoints=0; //it needs to be public so the targets can add to it and static so that all targets add to the same counter
    public int maxPoints = 8000;

    //public PointsBar pointsBar;
    public Text pointsText;
    // Start is called before the first frame update
    void Start()
    {
        totalPoints = 0;
       // pointsBar.SetMaxPoints(maxPoints,totalPoints);
        pointsText.text = ""+totalPoints;
    }


    // Update is called once per frame
    void Update()
    {
        //pointsBar.SetPoints(totalPoints);//it worked fine here but that means the bar will be updated periodically even if the value didn't change
        pointsText.text = ""+totalPoints;
    }

    public void addPoins(int addedPoints)
    {
        totalPoints += addedPoints;
        //pointsText.text = ""+totalPoints;
        //pointsBar.SetPoints(totalPoints); //when i added this line here it gave me a null object error
    }
}
