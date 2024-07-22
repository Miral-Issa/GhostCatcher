using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; //the camera that will help me in knowing the mouses' position
    [SerializeField] private int speed; // speed of movement
    float distanceToMouse;

    // Update is called once per frame
    void FixedUpdate() // Update() coused wierd laging in movement
    {
        speed = Mathf.Abs(speed); //return speed to its original value if the last movement was in oppeset direction
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //get the mouses' position according to camera not world 

        distanceToMouse = (transform.position - mouseWorldPosition).x; //how far is the mouse from the player
        

        if (distanceToMouse > 0) //if the mouse behind the player change the direction of movement
            speed *= -1;        
         if (Mathf.Abs(distanceToMouse)>1.5 && Mathf.Abs(distanceToMouse)<5) //if mouse is still close move slowly
        {   
            transform.position += new Vector3(speed, 0, 0)* Time.fixedDeltaTime;
            
        }else if(Mathf.Abs(distanceToMouse) > 5) //if mouse is far move faster
        {
            transform.position += new Vector3(speed*3, 0, 0) * Time.fixedDeltaTime;
        }
        
    }
}
