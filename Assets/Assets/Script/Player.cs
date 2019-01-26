using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        rb.velocity = Vector3.forward * Input.GetAxis("Vertical")
                    + Vector3.right * Input.GetAxis("Horizontal");

    }
}
