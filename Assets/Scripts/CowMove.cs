using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMove : MonoBehaviour {

    public float changeDirectionFrequency = 5f;
    
    private float changeDirectionTimer;
    private Quaternion turnDirection;

	// Use this for initialization
	void Start () {
        changeDirectionTimer = 0f;
        turnDirection = Quaternion.Euler(0, Random.Range(-90, 90), 0);
    }
	
	// Update is called once per frame
	void OnCollisionStay () {
        changeDirectionTimer += Time.deltaTime;

        if(changeDirectionTimer >= changeDirectionFrequency)
        {
            turnDirection = Quaternion.Euler(0, Random.Range(-90, 90), 0);
        }

        transform.position += transform.forward * Time.deltaTime;

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
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, turnDirection, 100 * Time.deltaTime);
        }
	}
}
