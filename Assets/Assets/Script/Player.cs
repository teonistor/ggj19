using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    static readonly Vector3 pickedUpLocalPosition = new Vector3(0f, 1.8f, 0f);

    Rigidbody rb;
    Resource pickedUp;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        rb.velocity = Vector3.forward * Input.GetAxis("Vertical")
                    + Vector3.right * Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && pickedUp != null) {
            pickedUp = pickedUp.Throw(transform.forward);
        }

    }

    void OnTriggerEnter (Collider other) {
        pickedUp = other.GetComponent<Resource>();
        if (pickedUp != null) {
            pickedUp.transform.parent = transform;
            pickedUp.transform.localPosition = pickedUpLocalPosition;
            pickedUp.gameObject.layer = gameObject.layer;
        }
    }
}
