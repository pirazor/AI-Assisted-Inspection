// Offsets camera's rendering from the transform's position.
using UnityEngine;
using System.Collections;

public class calibration : MonoBehaviour
{
    public Camera cam;
    public GameObject dmg;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {

        Matrix4x4 vpm = cam.worldToCameraMatrix * transform.worldToLocalMatrix;
        Debug.Log("projection matrix: "+vpm);
    }
}
