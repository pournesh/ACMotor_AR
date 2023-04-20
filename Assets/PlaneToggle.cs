using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneToggle : MonoBehaviour
{
    private ARPlaneManager planeManager;

    // Start is called before the first frame update
    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disablePlane()
    {
        planeManager.enabled = false;
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        
    }
        
}
