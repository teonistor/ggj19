using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionController : MonoBehaviour
{

    public float amplitudeY = 0.5f;
    public float omegaY = 0.5f;
    public float index;
    public float rotateSpeed;
    private float normalY;

    // Start is called before the first frame update
    void Start()
    {
        normalY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector3(0, normalY + y, 0);
        transform.Rotate(0, index * rotateSpeed, 0, Space.Self);

        if (!transform.parent.tag.Equals(Resource.resourceTag)) {
            Destroy(gameObject);
        }
    }
}
