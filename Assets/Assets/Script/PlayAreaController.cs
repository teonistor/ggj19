using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaController : MonoBehaviour
{
    /**
     * This models the play area
     * Players outside should be killed
     * It should shrink, once started, linearly to its minimum size
     */
    public bool isShrinking = false;
    public float minAreaSize = 100;
    public float shrinkAmmount = 0.1f;
    public SphereCollider myCollider;

    private void Start()
    {
        myCollider.isTrigger = true; //Make sure trigger is enabled
        myCollider = this.GetComponent<SphereCollider>();
    }

    void FixedUpdate()
    {
        if (isShrinking && this.transform.localScale.x > minAreaSize)
        {
            //TODO this better (also we don't want y axis shrinkage)
            this.transform.localScale -= new Vector3(shrinkAmmount, 0.0f, shrinkAmmount);
            myCollider.radius -= shrinkAmmount * 0.5f / 100;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            print("Ai murit, prostule"); //Teo approved
            Destroy(other.gameObject);
        }
        else
        {
            print("Nu tu, prostule" + other.gameObject.tag); //Teo approved
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Rau de tot: " + other.gameObject);
    }
}
