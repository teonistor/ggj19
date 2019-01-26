using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Resource : MonoBehaviour {
    const float throwVelocity = 5f;
    internal const string p1ResourceTag = "Player 1 resource",
                          p2ResourceTag = "Player 2 resource",
                            resourceTag = "Resource";

    Rigidbody rb;
    //Collider cld;
    int defaultLayer;
    public int value { get; private set; }

    void Start () {
        value = 10;
        rb = GetComponent<Rigidbody>();
        //cld = GetComponent<Collider>();
        defaultLayer = gameObject.layer;
    }

    internal Resource Throw (Vector3 direction) {
        transform.parent = null;
        //cld.isTrigger = false;
        //rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = Vector3.RotateTowards(direction, Vector3.up, Mathf.PI / 6f, float.PositiveInfinity)
            . normalized
            * throwVelocity;

        return null; // Asigned in Player
    }

    internal Resource PickUp (Transform newParent, Vector3 newLocalPosition, string newTag) {
        //rb.useGravity = false;
        transform.parent = newParent;
        transform.localPosition = newLocalPosition;
        tag = newTag;

        return this; // Asigned in Player
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.collider.tag == "Ground") {
            rb.isKinematic = true;
            //cld.isTrigger = true;
            //gameObject.layer = defaultLayer;
            gameObject.tag = resourceTag;
        }
    }

    //void OnTriggerEnter (Collider other) {

    //}
}

