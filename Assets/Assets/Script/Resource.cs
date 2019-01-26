using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Resource : MonoBehaviour {
    const float throwVelocity = 5f;

    Rigidbody rb;
    Collider cld;
    int defaultLayer;
    public int value { get; private set; }

    void Start () {
        value = 10;
        rb = GetComponent<Rigidbody>();
        cld = GetComponent<Collider>();
        defaultLayer = gameObject.layer;
    }

    internal Resource Throw (Vector3 direction) {
        transform.parent = null;
        cld.isTrigger = false;
        rb.isKinematic = false;
        rb.velocity = Vector3.RotateTowards(direction, Vector3.up, Mathf.PI / 4f, float.PositiveInfinity)
            . normalized
            * throwVelocity;

        return null; // Asigned in Player
    }

    //internal Resource PickUp (Vector3 holdingPosition) {
    //    rb.isKinematic = 
    //    transform.position = holdingPosition;

    //    return this; // Asigned in Player
    //}

    void OnCollisionEnter (Collision collision) {
        if (collision.collider.tag == "Ground") {
            rb.isKinematic = true;
            cld.isTrigger = true;
            gameObject.layer = defaultLayer;
        }
    }

    //void OnTriggerEnter (Collider other) {

    //}
}

