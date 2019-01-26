using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    static readonly Vector3 pickedUpLocalPosition = new Vector3(0f, 1.9f, 0f);

    const string verticalAxTemplate = "VerticalP{0}",
                 horizontalAxTemplate = "HorizontalP{0}",
                 throwAxTemplate = "ThrowP{0}",
                 myResourceTagTemplate = "Player {0} resource";

    [SerializeField][Range(1,2)] int playerNum;

    //[SerializeField] PlayerNum player;
    //[SerializeField] LayerMask[] layerMasks;
    //[SerializeField] Material[] materials;


    //[SerializeField] Tribe tribe; // TODO Cristi

    public string verticalAx { get; private set; }
    public string horizontalAx { get; private set; }
    public string throwAx { get; private set; }
    public string myResourceTag { get; private set; }

    Rigidbody rb;
    Resource pickedUp;
    [SerializeField] Tribe tribe;
	void Start () {
        verticalAx = string.Format(verticalAxTemplate, playerNum);
        horizontalAx = string.Format(horizontalAxTemplate, playerNum);
        throwAx = string.Format(throwAxTemplate, playerNum);
        myResourceTag = string.Format(myResourceTagTemplate, playerNum);

        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        rb.velocity = Vector3.forward * Input.GetAxis(verticalAx)
                    + Vector3.right * Input.GetAxis(horizontalAx);

        if (Input.GetButtonDown(throwAx) && pickedUp != null) {
            pickedUp = pickedUp.Throw(transform.forward);
        }

    }


    void Die () {
        this.pickedUp = null;
        if (tribe.UseLife()) {
            // respawn
        }
        else {
            // game over
        }
    }

    /// <summary>
    /// Check if we collided with a resource. If it is just lying around (tagged as "Resource"), collect it; otherwise
    /// it means it was thrown by the other player and hit us
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter (Collision collision) {
        Resource resource = collision.collider.GetComponent<Resource>();
        if (resource != null) {
            if (resource.tag.Equals(Resource.resourceTag)) {
                pickedUp = resource.PickUp(transform, pickedUpLocalPosition, myResourceTag);
            } else if (!resource.tag.Equals(myResourceTag)) {
                // TODO
                Debug.LogWarning("DEAD");
            }
        }
    }

    void OnTriggerEnter (Collider other) {
        Tribe tribe = other.GetComponent<Tribe>();
        if (tribe != null) {
            if (tribe.Equals(this.tribe)) {
                if (pickedUp != null) {
                    tribe.AddResources(pickedUp.value);
                    Destroy(pickedUp.gameObject);
                    pickedUp = null;
                }
            } else {
                print("What are you doing in the adversary's tribe...");
            }
        }
    }
}
