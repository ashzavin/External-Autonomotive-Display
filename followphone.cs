using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;
using UnityStandardAssets.Vehicles.Car;

public class followphone : MonoBehaviour
{

    float a;
    TextMesh DebugText2;
    string debugMessage = "message";
    public GameObject p;
    int flag;

    void Start()
    {
        p.SetActive(false);
        flag = 1;

        GameObject DebugObject = GameObject.FindGameObjectWithTag("TextM");
        DebugText2 = (TextMesh)DebugObject.GetComponent("TextMesh");
    }

    void Update()
    {
        a=Time.time;
        if (a >= 10.0f)
        {
            debugMessage = "time manse";
            DebugText2.text = debugMessage;
            p.SetActive(true);
            if (flag==1)
            {
                changefvalue();
            }
            
            
        }
            

        /*if(a >=13.0f && flag==1)
        {
            debugMessage = "position manse";
            DebugText2.text = debugMessage;
            
            transform.position = new Vector3(1.229f, 0.836f, 1.015f);
            transform.Rotate(-7.275001f, -104.032f, -623.658f, Space.World);
            flag = 0;
        }*/


        else
        {
            debugMessage = "Time: " + Time.time;
            DebugText2.text = debugMessage;
        }
        
        
            
       
    }
    void changefvalue()
    {

        //p.SetActive(true);
        //rend.sharedMaterial = material[1];
        debugMessage = "position manse";
        DebugText2.text = debugMessage;
        
        if(a>=15.0f)
        {
            p.transform.position = new Vector3(1.229f, 0.836f, 1.015f);
            p.transform.Rotate(-7.275001f, -104.032f, -623.658f, Space.World);
            flag = 0;
        }
        
        
    }



}
