using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    [SerializeField] private int speed;  //the speed of the target
    private int privateSpeed;
    [SerializeField] private GameObject border; //the borders of the scene to discover at which end the object is in
    float distaneToBorder;

    //so the update() knows if the target should move or not
    private bool isWandering = false;
    private bool isWalking = false;

    private bool clicked = false; //to know if its corrently being clicked by the mouse
    private float pointerDownTimer = 0f;//to know how long its being clicked
    public float requiredHoldTime;//time to wite befor it becomes a long click

    public float maxHoldPoints=800;
    public float holdPoints = 10f;

    //total player points
    PlayerPoints playerPoints;
    [SerializeField] GameObject pointsCounter;
    public int worth; //points to be added to the player when the target dies

    public MeterScript pointsMeter;//meter to display the points

    //to interact with the enemy
    public bool available = false;

    void Awake()
    {
        playerPoints = pointsCounter.GetComponent<PlayerPoints>();
    }
    void Start()
    {
        distaneToBorder = (transform.position - border.transform.position).x; //how far are you from the right border
        if (Mathf.Abs(distaneToBorder) < 22) //if you're farther than half the scene
            speed *= -1; //walk the opisit way
        //privateSpeed = speed;//save the speed so after the target stops because of the mouse it returns to its original speed

        pointsMeter.SetMaxHealth(maxHoldPoints);//set the maxt points or the meter
    }
    void OnMouseDown() //to know when the mouse clicks the collider of the object
    {
        clicked = true; //it is being clicked now
        holdPoints += 100;
        speed = 0;//stop moving while being clicked
        available = true;

    }

    void OnMouseUp() //to know when the mouse isn't being clicked anymore
    {
        clicked = false; //its not clicked anymore
        pointerDownTimer = 0f;//reset the timer of each click hold

        //  speed = privateSpeed/2; //walk again but slower
        //stay still for now
    }

    void Update()
    {
        if(clicked)
        {
            pointerDownTimer += Time.deltaTime;//after its clicked start to calculate for how long its being clicked
            if (pointerDownTimer>requiredHoldTime)//if it has been clicked for long enough
            { 
                holdPoints += 1f;
            }
            
        }
        if (holdPoints >= maxHoldPoints)
        {
            playerPoints.addPoins(worth); //add points to the player
            Destroy(this.gameObject);//then delete it
        }
        else if(holdPoints <= 0)
        {
            Destroy(this.gameObject);//delete the object if the enemy capture it
        }
        
    }
    void FixedUpdate()
    {
        pointsMeter.SetHealth(holdPoints); //update the meter to the current points
        if (isWandering==false)//every time the fun waitRandomTime end call it again
        {
            StartCoroutine(waitRandomTime());
        }
        if (isWalking == true)//if it's time to walk move the target
        {
            transform.position += new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
        }
        deleteObject();//see if the object should be deleted
    }
    
    IEnumerator waitRandomTime() //the behavior of the object is programmed here
    {
        float walkWait = Random.Range(2f, 3f); //random time to wait between walking time
        float walkTime = Random.Range(3f, 5f); //time for the object to walk in

        isWandering = true; //now the target is paused
        yield return new WaitForSeconds(walkWait); //wait the time of wandering
        isWalking = true; //now the target is walking
        yield return new WaitForSeconds(walkTime); //allow it to walk for this time
        isWalking = false; //stop it from walkin

        isWandering = false; //so the fun get called again in fixedupdate and the target get stoped again

    }

    public void deleteObject() //delete the object if needed
    {
        if (transform.position.x > 30 || transform.position.x < -30) //is the object outside the scene?
            Destroy(this.gameObject);//then delete it
    }
}
