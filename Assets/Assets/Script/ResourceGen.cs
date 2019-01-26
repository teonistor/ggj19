using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGen : MonoBehaviour {

    [SerializeField] GameObject[] resources;

    IEnumerator Start () {
        for (WaitForSeconds wait = new WaitForSeconds(Random.Range(2f, 10f))
                ; ;         wait = new WaitForSeconds(Random.Range(20f, 30f))) {
            yield return wait;

            Instantiate(RandomResource(), transform, false).transform.parent = null;
        }
    }

    GameObject RandomResource () {
        return resources[Random.Range(0, resources.Length)];
    }
}
