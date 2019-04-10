using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardsGetBigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = Time.deltaTime * 6;
        transform.position = Vector3.MoveTowards(transform.position, transform.forward, step);
	}

    private void OnTriggerEnter(Collider other)
    {
        transform.localScale *= 2;
        Destroy(other.gameObject);
    }
}
