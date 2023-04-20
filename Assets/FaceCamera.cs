using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FaceCamera : MonoBehaviour
{
    Transform cam;
    Vector3 targetAngle = new Vector3(0, -180, 0);
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam);
        targetAngle = transform.localEulerAngles;

        targetAngle.x = 0;
        targetAngle.z = -90;
        transform.localEulerAngles = targetAngle;
    }
}
