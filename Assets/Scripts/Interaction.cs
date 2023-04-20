using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    Ray ray;
    private string tagname;
    Animator anim;
    bool expanded,running = false;


    

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
                tagname = hit.collider.gameObject.tag;

                switch (tagname)
                {
                    case "Fan":
                        Visible("fantext");
                        break;
                    case "Stator":
                        Visible("statortext");
                        break;
                    case "Winding":
                        Visible("windingText");
                        break;
                    case "Rotor":
                        Visible("rotortext");
                        break;
                    case "Bearing":
                        Visible("Bearing");
                        break;
                    
                }
            }
        }    
    }

    public void clearTextPanel()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("hasInfo"))
        {
            go.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void Visible(string name)
    {
        clearTextPanel();
        if (name == "Bearing")
        {
            GameObject.Find("bearingtext1").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("bearingtext2").transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GameObject.Find(name).transform.localScale = new Vector3(1, 1, 1);

        }




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

    public void MotorRunning()
    {
        if (!running)
        {
            anim.SetBool("isRunning", true);
            running = true;
        }
        else
        {
            
            anim.SetBool("isRunning", false);
            running = false;
        }
    }







}
