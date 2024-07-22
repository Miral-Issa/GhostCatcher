using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBar : MonoBehaviour
{
    public Slider slider; //the slider that will display the points
    public Gradient gradient;
    public Image fill;
                         
    public void SetPoints(int totalPoints)
    {
        slider.value = totalPoints;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxPoints(int maxPoints,int totalPoints)
    {
        slider.maxValue = maxPoints;
        slider.value = totalPoints;
        fill.color = gradient.Evaluate(0f);
    }
}
