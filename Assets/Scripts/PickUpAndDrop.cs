using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{

    public float speed = 10f;
    public ParticleSystem squish;

    private bool isHeld;
    private bool isSquished;
    private GameObject heldObject;
    private GameObject squishObject;

    private float time = 0;

    // Use this for initialization
    void Start()
    {
        isHeld = false;
    }

    void Update()
    {

        if (Input.GetAxis("Fire2") > 0 && !isHeld)
        {
            PickUpCow();
        }
        if (Input.GetAxis("Fire2") < 1 && isHeld)
        {
            DropCow();
        }
        if (Input.GetAxis("Fire1") > 0 && !isHeld)
        {
            SquishCow();
            time = 0;
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
                if (!hit.collider.GetComponent<CowMove>().isInfected)
                {
                    heldObject = hit.collider.gameObject;
                    heldObject.layer = 2;
                    isHeld = true;
                }
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

    void SquishCow()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.tag == "Cow")
            {
                if(hit.collider.GetComponent<CowGrow>().GetGrown()
                    && !hit.collider.GetComponent<CowMove>().isInfected)
                {
                    Destroy(hit.collider.gameObject);
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().score += 10;
                }

                squishObject = hit.collider.gameObject;


                if (!(squishObject.GetComponent<SquishCheck>().isSquished))
                {
                    squishObject.GetComponent<CowMove>().enabled = false;
                    Rigidbody rb = squishObject.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    Destroy((Instantiate(squish, squishObject.transform.position, squishObject.transform.rotation)).gameObject, 1f);
                    squishObject.transform.localScale -= new Vector3(-0.03f, 0.04f, -0.03f);
                    squishObject.GetComponent<SquishCheck>().isSquished = true;
                    time += Time.deltaTime;
                }
                Destroy(squishObject, 1f);
            }
        }
    }

    public bool GetHeld()
    {
        return isHeld;
    }
}
