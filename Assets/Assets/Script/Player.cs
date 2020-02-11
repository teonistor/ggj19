using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    static readonly float velocityMagnitudeSafe = 1.5f;

    static readonly Vector3 pickedUpLocalPosition = new Vector3(0f, 1.26667f, 0f);

    const string verticalAxTemplate = "VerticalP{0}",
                 horizontalAxTemplate = "HorizontalP{0}",
                 throwAxTemplate = "ThrowP{0}",
                 myResourceTagTemplate = "Player {0} resource";

    [SerializeField] [Range(1, 2)] int playerNum;
    [SerializeField] Tribe tribe;


    public string verticalAx { get; private set; }
    public string horizontalAx { get; private set; }
    public string throwAx { get; private set; }
    public string myResourceTag { get; private set; }
    public GameObject teamRagdoll;

    Rigidbody rb;
    Resource pickedUp;
    SimpleCharacterControl scc;
    Vector3 spawnPoint;

    void Start()
    {
        verticalAx = string.Format(verticalAxTemplate, playerNum);
        horizontalAx = string.Format(horizontalAxTemplate, playerNum);
        throwAx = string.Format(throwAxTemplate, playerNum);
        myResourceTag = string.Format(myResourceTagTemplate, playerNum);
        spawnPoint = transform.position;

        rb = GetComponent<Rigidbody>();
        scc = GetComponent<SimpleCharacterControl>();
    }

    void Update()
    {
        if (Input.GetButtonDown(throwAx) && pickedUp != null)
        {
            pickedUp = pickedUp.Throw(transform.forward);
        }
    }


    internal void Die()
    {
        pickedUp = null;
        if (tribe.UseLife())
        {
            // respawn
            scc.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            Instantiate(teamRagdoll, transform.position, transform.rotation);
            StartCoroutine(Respawn(spawnPoint));
        }
        else
        {
            // game over
            // this will notify the GameController that player is kill
            Destroy(gameObject);
        }
    }

    IEnumerator Respawn(Vector3 spawnResetPoint)
    {
        //Wait a bit before transfering the player to spawn
        yield return new WaitForSeconds(2);
        transform.position = spawnResetPoint;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        scc.enabled = true;
    }

    /// <summary>
    /// Check if we collided with a resource. If it is just lying around (tagged as "Resource"), collect it; otherwise
    /// it means it was thrown by the other player and hit us
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        Resource resource = collision.collider.GetComponent<Resource>();
        if (resource != null)
        {
            Rigidbody rbObject = resource.GetComponent<Rigidbody>();
            if (resource.tag.Equals(Resource.resourceTag) && rbObject.velocity.magnitude < velocityMagnitudeSafe)
            {
                if (pickedUp == null)
                {
                    pickedUp = resource.PickUp(transform, pickedUpLocalPosition, myResourceTag);
                }
            }
            else if (!resource.tag.Equals(myResourceTag))
            {
                Die();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Future note: We decided that the resource will enter any tribe regardless of who is carrying it. Tribe.OnTriggerEnter takes
        // care of score and resource destruction.
        Tribe tribe = other.GetComponent<Tribe>();
        if (tribe != null)
        {
            //if (tribe.Equals(this.tribe)) {
            //    if (pickedUp != null) {
            //        tribe.AddResources(pickedUp.value);
            //        Destroy(pickedUp.gameObject);
            pickedUp = null;
        }
        //} else {
        //    print("What are you doing in the adversary's tribe...");
        //}
        //}
    }
}
