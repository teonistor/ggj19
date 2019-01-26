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
    private CapsuleCollider myCollider;

    private void Start()
    {
        myCollider = this.GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if (isShrinking && myCollider.radius > minAreaSize)
        {
            myCollider.radius -= shrinkAmmount;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            print("Ai murit, prostule"); //Teo approved
            Destroy(other.gameObject);
        }
    }
}
