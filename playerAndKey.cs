using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAndKey : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    public GameObject kaappiKello;

    private Rigidbody rb;
    private int count;
    // Use this for initialization
    void Start()
    {
       // kaappiKello = GetComponentInChildren<Isoviisari>().enabled = true;
        rb = GetComponent<Rigidbody>();
        count = 5;
        SetCountText();
        winText.text = "";
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }


void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Key"))
    {
            Debug.Log("KEY");
        other.gameObject.SetActive(false);
        count = count - 1;
        SetCountText();
    }
}



void SetCountText()
{
    countText.text = "Avaimia jäljellä: " + count.ToString();
    if (count <= 0)
    {
            
            GameObject varGameObject = GameObject.Find("minuuttiviisari");
            GameObject varGameObject2 = GameObject.Find("tuntiviisari");
            GameObject varGameObject3 = GameObject.Find("heliuriurirlriui");
            GameObject varGameObject4 = GameObject.Find("Audio Source");

            varGameObject.GetComponent<isoviisari>().enabled = true;
            varGameObject2.GetComponent<Tuntiviisari>().enabled = true;
            varGameObject3.GetComponent<a>().enabled = true;
            //varGameObject4.GetComponent<AudioSource>().enabled = true;

            Debug.Log("FOUND IT");
            winText.text = "VOITIT PELIN!";
    }
}
}
