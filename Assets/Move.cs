using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Rigidbody rb;
       
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector3.forward * Input.GetAxis("VerticalP1") * 10 + Vector3.right * Input.GetAxis("HorizontalP1") * 10;
    }
}
