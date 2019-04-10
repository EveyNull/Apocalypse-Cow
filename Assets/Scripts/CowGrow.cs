using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGrow : MonoBehaviour {

    private bool grown = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Hay")
        {
            Destroy(collision.collider.gameObject);
            transform.localScale = transform.localScale * 2;
        }
    }

    bool GetGrown()
    {
        return grown;
    }
}
