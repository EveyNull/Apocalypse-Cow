using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickToSpawnHay : MonoBehaviour {

    public GameObject hayBale;
    public GameObject planet;

    private bool haySpawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Fire2") > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Planet" && !haySpawned)
                {
                    haySpawned = true;
                    GameObject newCow = Instantiate(hayBale, hit.point, Quaternion.Euler(0,0,0));
                    newCow.transform.SetParent(planet.transform);
                }
            }
        }
        if(Input.GetAxis("Fire2") == 0)
        {
            haySpawned = false;
        }
	}
}
