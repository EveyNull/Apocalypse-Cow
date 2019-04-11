using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGrow : MonoBehaviour {
    
    private bool isGrown = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Hay")
        {
            Destroy(collision.collider.gameObject);
            if (!isGrown && !GetComponent<CowMove>().isInfected)
            {
                isGrown = true;
                transform.localScale = transform.localScale * 2;
            }
        }
    }

    public bool GetGrown()
    {
        return isGrown;
    }
}
