using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;



public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn, visual, floor, BDetail,BAnim,text;

    bool object_spawned =false;
    private Placeindi pi;
    private GameObject obj;
    private ARPlaneManager planeManager;
    Animator anim;
    Interaction inter;


    void Awake()
    {
        planeManager = floor.GetComponent<ARPlaneManager>();
        pi = FindObjectOfType<Placeindi>();


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (!object_spawned && pi.isvisualactive)
            {
                

                Spawn();
            }
        }
    }

    public void Spawn()
    {
        
        obj= Instantiate(objectToSpawn, pi.transform.position, pi.transform.rotation);
        //obj.transform.LookAt(Camera.main.transform);
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

        getGO().MotorExpand();
        
      
    }

    public void Motorrotate()
    {
        //inter = getGO();
        getGO().MotorRunning();
    }

    Interaction getGO()
    {
        return GameObject.FindGameObjectWithTag("Motor").GetComponent<Interaction>();
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
