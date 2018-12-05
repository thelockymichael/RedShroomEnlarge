using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMushroom : MonoBehaviour {

    Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 5f;



    public IEnumerator Awesome()
    {
        minScale = Player.transform.localScale;
      

        if (repeatable)
        {
            Debug.Log("GOT EM");
            yield return RepeatLerp(minScale, maxScale, duration);
            yield return RepeatLerp(maxScale, minScale, duration);
        }
      
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            Player.transform.localScale = Vector3.Lerp(a, b, i);
 

            yield return null;
        }
    }

    // Player variables

    public GameObject Player;

	// Use this for initialization
/*	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}



  private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            //Enlarge();
            Debug.Log("TOUCHED");
           StartCoroutine(Awesome());
          //  Player.transform.localScale += new Vector3(1, 1, 1);
        
        }

    }


    
}

