using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateBridge : MonoBehaviour {

    //public Transform target;
   
   // public float speed = 5.0f;
  
    private bool Switch = false;

    //values that will be set in the Inspector
    public GameObject bridge;
    public Transform bridgeTarget;
    public Transform pressurePlate;
    public float RotationSpeed;
    public float speed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;


    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("puzzleBall"))
        {
            Debug.Log("IT HAS TOUCHED");
            Switch = true;
        }

    }

    void FixedUpdate()
    {
    
        // create the direction for our target
        _direction = (bridgeTarget.position - bridge.transform.position).normalized;


       // create the rotation we need to be in to look at the target
         _lookRotation = Quaternion.LookRotation(_direction);

     
        // If Switch is true, start rotating bridge to its destined position
        if (Switch)
        {
            
            bridge.transform.rotation = Quaternion.Slerp(bridge.transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
            transform.position = Vector3.MoveTowards(transform.position, pressurePlate.position, speed * Time.deltaTime);
        }
      
      
    }
}