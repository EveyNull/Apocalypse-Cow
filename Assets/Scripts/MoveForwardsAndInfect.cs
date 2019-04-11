using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardsAndInfect : MonoBehaviour {

    public GameObject otherCow;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<CowMove>().isInfected = true;
        gameObject.GetComponent<CowMove>().speed = 0.5f;
        gameObject.GetComponent<Renderer>().materials[1].color = Color.red;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Cow"
            && !collision.collider.GetComponent<CowMove>().isInfected)
        {
            
            collision.collider.gameObject.AddComponent<MoveForwardsAndInfect>();
        }
    }
}
