using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardsAndInfect : MonoBehaviour {

    public GameObject otherCow;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        float step = Time.deltaTime * 6;
        transform.position = Vector3.MoveTowards(transform.position, otherCow.transform.position, step);

    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().materials[1];
    }
}
