using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGen : MonoBehaviour {

    [SerializeField] GameObject[] resources;
    [SerializeField] float firstWaitShort = 2f, firstWaitLong = 10f, waitShort = 20f, waitLong = 30f;
    [SerializeField] int resourceValue = 15;

    bool spawn = true;

    IEnumerator Start () {
        for (WaitForSeconds wait = new WaitForSeconds(Random.Range(firstWaitShort, firstWaitLong))
                ; ;         wait = new WaitForSeconds(Random.Range(waitShort, waitLong))) {
            yield return wait;

            if (spawn) {
                spawn = false;
                Resource sr = Instantiate(RandomResource(), transform, false).GetComponent<Resource>();
                sr.value = resourceValue;
                sr.transform.parent = null;
            }
        }
    }

    GameObject RandomResource () {
        return resources[Random.Range(0, resources.Length)];
    }

    void OnTriggerExit(Collider other) {
        spawn = true;
    }
}
