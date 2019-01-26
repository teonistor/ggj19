using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        print("Entered " + other.gameObject.name);
    }
}

public abstract class Resource {
    internal abstract float Value { get; }
}

public class Rock : Resource {
    internal override float Value {
        get {
            return 14;
        }
    }
}
