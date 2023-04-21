using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    Ray ray;
    private string tagname;
    Animator anim;
    bool expanded,running = false;

    [SerializeField]
    List<GameObject> motorParts = new List<GameObject>();
    [SerializeField]
    List<GameObject> panels = new List<GameObject>();


    

    // Start is called before the first frame update
    void Start()
    {
        clearTextPanel();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) 
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began && expanded)
        {
             ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Clicking");


                GameObject name = hit.collider.gameObject;
                if (motorParts.Contains(name))
                {
                    int nameIndex = motorParts.IndexOf(name);
                    visibleText(nameIndex);
                }
            }
        }    
    }

    

    public void clearTextPanel()
    {
        

        foreach (GameObject go in panels)
        {
            go.transform.localScale = Vector3.zero;
        }
    }



    void visibleText(int pos)
    {
        clearTextPanel();

        if(pos ==0 || pos==5)
        {
            scaleup(0);
            scaleup(5);
        }
        else
        {
            scaleup(pos);

        }

    }

    void scaleup(int x)
    {
        panels[x].transform.localScale = Vector3.one;

    }



    public void MotorRunning()
    {

        running = !running;
        anim.SetBool("isRunning", running);

       
    }

    public void MotorExpand()
    {
        
        if (!expanded)
        {
            anim.SetBool("isExpand", true);
            expanded = true;
        }
        else
        {
            clearTextPanel();
            anim.SetBool("isExpand", false);
            expanded = false;
        }



    }







}
