using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField] Transform player;
    Vector3 delta;

    // Aspect ratio fixer code borrowed from the 2017 game
    [SerializeField] float minAspectRatio;
    Camera cam;
    Rect defaultViewport;

    IEnumerator Start () {
        delta = transform.position - player.transform.position;

        cam = GetComponent<Camera>();
        defaultViewport = cam.rect;

        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true) {
            float screenRatio = (float)Screen.width / Screen.height;
            if (screenRatio * 0.5f < minAspectRatio) {
                Rect viewport = defaultViewport;
                viewport.height = 0.5f * screenRatio / minAspectRatio;
                viewport.y = 0.5f - 0.5f * viewport.height;
                cam.rect = viewport;
            }
            else {
                cam.rect = defaultViewport;
            }
            yield return wait;
        }
    }

    void LateUpdate() {
        transform.position = player.transform.position + delta;
    }
}
