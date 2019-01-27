using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Resource : MonoBehaviour {
    const float throwVelocity = 10f;
    internal const string p1ResourceTag = "Player 1 resource",
                          p2ResourceTag = "Player 2 resource",
                            resourceTag = "Resource";

    Rigidbody rb;
    public int value;

    void Start () {
        rb = GetComponent<Rigidbody>();
        GetComponentInChildren<TextMesh>().text = value.ToString();
    }

    internal Resource Throw (Vector3 direction) {
        transform.parent = null;
        rb.isKinematic = false;
        rb.velocity = Vector3.RotateTowards(direction, Vector3.up, Mathf.PI / 20f, float.PositiveInfinity)
            . normalized
            * throwVelocity;
        

        return null; // Asigned in Player
    }

    internal Resource PickUp (Transform newParent, Vector3 newLocalPosition, string newTag) {
        rb.isKinematic = true;
        transform.parent = newParent;
        transform.localPosition = newLocalPosition;
        tag = newTag;

        return this; // Asigned in Player
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.collider.tag == "Ground") {
            gameObject.tag = resourceTag;
        }
    }
}
