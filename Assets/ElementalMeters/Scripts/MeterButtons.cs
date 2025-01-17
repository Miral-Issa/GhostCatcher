﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterButtons : MonoBehaviour
{
    public MeterScript healthMeter; //this allows you to link this script to the meter's script via the inspector
    public int currentHealth; //defines the variable you'd like to keep track of
    public int maxHealth = 60; //defines the maximum value of your variable (keep it at a multiple of 8 so that it matches the meter's sections)
    public GameObject target;


    void Start()
    {
        currentHealth = maxHealth; //sets your variable to maximum from the start
        //currentHealth = 0;
        healthMeter.SetMaxHealth(maxHealth); //sets your meter's fill to maximum from the start
        //healthMeter.SetMaxHealth(0);
        currentHealth = 0;
        healthMeter.SetHealth(currentHealth);
    }


    void FixedUpdate()
    {
        healthMeter.SetHealth(currentHealth); //links your variable to the meter's fill
        if (currentHealth == maxHealth)
            delete();

    }

    public void Increase()
    {

            currentHealth = 80; //increases the variable's value by 10
    }

    public void Decrease()
    {

            currentHealth -= 10; //decreases the variable's value by 10
    }
    private void delete()
    {
        Destroy(target);
    }
}
