﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;
using UnityStandardAssets.Vehicles.Car;

public class logicControl : MonoBehaviour
{
    public UnityEvent proximityEvent;
    public UnityEvent contactEvent;
    public UnityEvent actionEvent;
    public UnityEvent defaultEvent;

    float simResetTime = 25.0f;

    TextMesh DebugText;
    string debugMessage = "Default message";

    GameObject startButtonProximityObject;
    CarUserControl carControl;

    float startTime;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);

        //Get debug message refrence
        GameObject DebugObject = GameObject.FindGameObjectWithTag("Debug");
        DebugText = (TextMesh)DebugObject.GetComponent("TextMesh");

        //Get start button refrence
        startButtonProximityObject = GameObject.FindGameObjectWithTag("StartButtonProximity");
        rend = GetComponent<Renderer>();

        //Get vehicle refrence
        GameObject carObject = GameObject.FindGameObjectWithTag("Player");
        carControl = (CarUserControl)carObject.GetComponent("CarUserControl");
        carControl.drive = false;
       
    }

    void InitiateEvent(InteractableStateArgs state)
    {
        if (state.NewInteractableState == InteractableState.ProximityState)
        {
            debugMessage = "Starting vehicle";
            DebugText.text = debugMessage;

            proximityEvent.Invoke();

            //Dissable start button
            startTime = Time.time;
            rend.enabled = false;
            startButtonProximityObject.SetActive(false);

            //Start vehicle
            carControl.startTime = Time.time;
            carControl.drive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startTime+simResetTime)
        {
            rend.enabled = true;
            startButtonProximityObject.SetActive(true);
            carControl.reset();
        }
    }

}


