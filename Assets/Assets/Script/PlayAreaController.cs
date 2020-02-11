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
    public bool isShrinking;
    public float minAreaSize;
    public float shrinkAmmount;

    SphereCollider myCollider;

    private void Start()
    {
        myCollider = this.GetComponent<SphereCollider>();
        myCollider.isTrigger = true; //Make sure trigger is enabled
    }

    void FixedUpdate () {
        if (isShrinking) {
            if (transform.localScale.x < minAreaSize) {
                isShrinking = false;
            } else {
                // (we don't want y axis shrinkage)
                this.transform.localScale -= new Vector3(shrinkAmmount, 0.0f, shrinkAmmount);
                myCollider.radius -= shrinkAmmount * 0.5f / transform.localScale.y;
            }
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            other.GetComponent<Player>().Die();
        }
    }
}
