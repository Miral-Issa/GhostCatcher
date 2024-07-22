using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Target; //the target which the camera will follow
    public Vector3 offset; //to make sure the camera will stay away from the player in z and y to keep the player visible 
    [Range(1, 10)]
    public float smoothFactor; //to smooth the movment and make not look sudden

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = Target.position + offset; //the new position we want for the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime); //make the change in position liner and smooth
        transform.position = smoothedPosition; //now change the position
    }
}
