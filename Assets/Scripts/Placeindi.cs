using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class Placeindi : MonoBehaviour
{
    private ARRaycastManager rayManager;
    [SerializeField]public GameObject visual;
    public bool isvisualactive = false;
    [SerializeField]public TextMeshProUGUI infotext;

    private void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
       
        visual.SetActive(false);

    }


    private void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy && isvisualactive == false)
            {
                visual.SetActive(true);
                isvisualactive = true;
                infotext.text = "Tap on screen to Place Object";

            }

        }
    }
}
