using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{

    public float speed = 10f;

    private bool isHeld;
    private GameObject heldObject;

    // Use this for initialization
    void Start()
    {
        isHeld = false;
    }

    void Update()
    {

        if (Input.GetAxis("Fire1") > 0 && !isHeld)
        {
            PickUpCow();
        }
        if (Input.GetAxis("Fire1") < 1 && isHeld)
        {
            DropCow();
        }
        if (isHeld)
        {
            MoveObject();
        }
    }
    void PickUpCow()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Cow")
            {
                heldObject = hit.collider.gameObject;
                heldObject.layer = 2;
                isHeld = true;
            }
        }
    }
    void MoveObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        heldObject.transform.position = hit.point;

    }

    void DropCow()
    {
        heldObject.layer = 0;
        heldObject = null;
        isHeld = false;
    }

    public bool GetHeld()
    {
        return isHeld;
    }
}
