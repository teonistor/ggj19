using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaController : MonoBehaviour
{
    /**
     * This models the play area
     * Players outside should be killed
     * It should shrink, once started, linearly to its minimum size
     */
    public bool isShrinking = false;
    public float minAreaSize = 500;
    public float shrinkAmmount = 1f;
    private CapsuleCollider collider;

    private void Start()
    {
        collider = this.GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if (isShrinking && collider.radius > minAreaSize)
        {
            collider.radius -= shrinkAmmount;
        }
    }
}
