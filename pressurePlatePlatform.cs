using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlatePlatform : MonoBehaviour {

    //public Transform target;
   
   // public float speed = 5.0f;


    //values that will be set in the Inspector
 
   
    public Transform pressurePlate;
    public GameObject platform;
  

    public Transform destinationSpot;
    public Transform originSpot;
    public float speed = 5.0f;
    public float pauseDuration = 5.0f;

    private float platformTimer = 0.0f;
    private bool Switch = false;

    private bool Activate = false;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;


    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("puzzleBall"))
        {
            Debug.Log("IT HAS TOUCHED");
            Activate = true;

        }

    }

    void FixedUpdate()
    {
        if (Activate)
        {
            // For these 2 if statements, it's checking the position of the platform.
            // If it's at the destination spot, it sets Switch to true.
            if (platform.transform.position == destinationSpot.position && Switch == false)
            {
                Switch = true;
                platformTimer = 0.0f;

            }
            if (platform.transform.position == originSpot.position && Switch == true)
            {
                Switch = false;
                platformTimer = 0.0f;

            }
        }



        if (Activate)
        {
            // If Switch is true, start rotating bridge to its destined position
            if (Switch)
            {

                transform.position = Vector3.MoveTowards(transform.position, pressurePlate.position, speed * Time.deltaTime);


                // If Switch is true, it tells the platform to move to the origin.

                // If the platformTimer is more than the pauseDuration then start 
                // moving the platform else make the platformTImer count up.

                if (platformTimer >= pauseDuration)
                {
                    Debug.Log("PLATFORM STARTS MOVING");
                    platform.transform.position = Vector3.MoveTowards(platform.transform.position, originSpot.position, speed * Time.deltaTime);
                }
                else
                {
                    platformTimer += Time.deltaTime;
                }
            }
            else
            {
                // If Switch is false, it tells the platform to move to the destination.

                // If the platformTimer is more than the pauseDuration then start 
                // moving the platform else make the platformTImer count up.

                if (platformTimer >= pauseDuration)
                {
                    Debug.Log("PLATFORM MOVES BACK");

                    platform.transform.position = Vector3.MoveTowards(platform.transform.position, destinationSpot.position, speed * Time.deltaTime);
                }
                else
                {
                    platformTimer += Time.deltaTime;
                }
            }
        }
            

    }
}