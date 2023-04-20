using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;



public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn, visual, floor, BDetail,BAnim,text;
    //[SerializeField] private GameObject Stator, rotor, fan, bearing1, bearing2, winding;

    bool object_spawned =false;
    private Placeindi placementndicator;
    private GameObject obj;
    private ARPlaneManager planeManager;
    Animator anim;
    bool expanded = false;
    Interaction inter;


    void Awake()
    {
        planeManager = floor.GetComponent<ARPlaneManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Cube");
        //object_spawned = false;
        placementndicator = FindObjectOfType<Placeindi>();

    //obj.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (!object_spawned && placementndicator.isvisualactive)
            {
                

                Spawn();
            }
            
        }
       /* if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {

            GameObject go = hit.collider.gameObject;
            if (go.tag == "Fan")
            {
                fan.SetActive(true);
            }

            if (go.tag == "Bearing")
            {
                bearing1.SetActive(true);
                bearing2.SetActive(true);
            }
        } */
    }


    // Start is called before the first frame update
   

    // Update is called once per frame
   

    public void Spawn()
    {
        
        obj= Instantiate(objectToSpawn, placementndicator.transform.position, objectToSpawn.transform.rotation);
        visual.SetActive(false);
        anim = obj.GetComponent<Animator>();

        planeManager.enabled = false;
         foreach (var plane in planeManager.trackables)
         {
             plane.gameObject.SetActive(false);
         }
        object_spawned = true;

        BAnim.SetActive(true);
        BDetail.SetActive(true);
        text.SetActive(false);
     
    }

    public void MotorExpand()
    {

        inter = GameObject.FindGameObjectWithTag("Motor").GetComponent<Interaction>();
        inter.MotorExpand();
       /* if (!expanded)
        {
            anim.SetBool("isExpand", true);
            expanded = true;
        }
        else
        {
            Interaction inter = new Interaction();
            inter.clearTextPanel();
            anim.SetBool("isExpand", false);
            expanded = false;
        }
        */
    }

    public void Motorrotate()
    {
        inter = GameObject.FindGameObjectWithTag("Motor").GetComponent<Interaction>();
        inter.MotorRunning();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }


}
