using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMove : MonoBehaviour {

    public float changeDirectionFrequency = 5f;
    public bool isInfected = false;

    public float speed = 1f;

    private float changeDirectionTimer;
    private Quaternion turnDirection;

	// Use this for initialization
	void Start () {
        changeDirectionTimer = 0f;
        turnDirection = Quaternion.Euler(0, Random.Range(-90, 90), 0);
    }
	
	// Update is called once per frame
	void OnCollisionStay () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        changeDirectionTimer += Time.deltaTime;

        if(changeDirectionTimer >= changeDirectionFrequency)
        {
            turnDirection = Quaternion.Euler(0, Random.Range(-90, 90), 0);
        }

        transform.position += transform.forward * Time.deltaTime * speed;

        if(!isInfected)
        { 
        GameObject[] hayBales = GameObject.FindGameObjectsWithTag("Hay");
            if (hayBales.Length > 0)
            {
                int smallestDistance = 0;
                float distance = Vector3.Distance(transform.position, hayBales[0].transform.position);
                for (int i = 1; i < hayBales.Length; i++)
                {
                    if (Vector3.Distance(transform.position, hayBales[i].transform.position) < distance)
                    {
                        distance = Vector3.Distance(transform.position, hayBales[i].transform.position);
                        smallestDistance = i;
                    }
                }
                if (distance < 8f)
                {
                    transform.LookAt(hayBales[smallestDistance].transform, transform.up);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, turnDirection, 100 * Time.deltaTime);
                }
            }
        }
        else
        {
            GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
            if (cows.Length > 0)
            {
                int smallestDistance = 0;
                float distance = Vector3.Distance(transform.position, cows[0].transform.position);
                for (int i = 1; i < cows.Length; i++)
                {
                    if (Vector3.Distance(transform.position, cows[i].transform.position) < distance
                        && !cows[i].GetComponent<CowMove>().isInfected)
                    {
                        distance = Vector3.Distance(transform.position, cows[i].transform.position);
                        smallestDistance = i;
                    }
                }
                if (distance < 8f)
                {
                    transform.LookAt(cows[smallestDistance].transform, transform.up);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, turnDirection, 100 * Time.deltaTime);
                }
            }
        }
	}
}
