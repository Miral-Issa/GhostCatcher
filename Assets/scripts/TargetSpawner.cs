using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target; //the object you want to spawn
    float nextSpawn = 0.0f; //when next spawn gonna happen
    public float spawnRate = 1.0f; //time between each spawn
    Vector3 whereToSpawn; //where to place the object
    float Randy;//random y value to place the object in
    float Randx;//random x value to choose end of the screen the object gonna spawn in
    int x;//the two scene's end to choose from


   

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn) //if the time of next frame is reached
        {
            nextSpawn += spawnRate;//update the next spawn time
            Randy = Random.Range(-2.7f,-1.3f);//chose a random y value

            //choose randomly between 2 values of x
            Randx = Random.Range(-1f, 1f);
            if(Randx<0)
            {
                x = -23;
            }else if(Randx>0)
            {
                x = 23;
            }
            whereToSpawn = new Vector3(x, Randy, 0); //now create the coordinates for the object
            Instantiate(target, whereToSpawn, Quaternion.identity); //now create the object at the given coordinates
        }
    }
}
