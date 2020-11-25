using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;
using UnityStandardAssets.Vehicles.Car;

public class buttonlist : MonoBehaviour
{
    public UnityEvent proximityEvent;
    public UnityEvent contactEvent;
    public UnityEvent actionEvent;
    public UnityEvent defaultEvent;

    //public GameObject p;
    //public GameObject q;

    CarUserControl carControl;
    TextMesh DebugText;
    string debugMessage = "Default message";

    //code by Asha
    /*public Material[] material;
    Renderer rend;*/
    int flag;
    int d;


    // Start is called before the first frame update
    void Start()
    {

        //q.SetActive(false);

        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);

        //Get debug message refrence
        GameObject DebugObject = GameObject.FindGameObjectWithTag("Debug");
        DebugText = (TextMesh)DebugObject.GetComponent("TextMesh");

        //Get vehicle refrence
        //GameObject carObject = GameObject.FindGameObjectWithTag("Player");
        //carControl = (CarUserControl)carObject.GetComponent("CarUserControl");

        //keeping the button material green after pressing the button
        //rend = GetComponent<Renderer>();
        flag = 0;
        d = 0;
    }

    void InitiateEvent(InteractableStateArgs state)
    {

        if (state.NewInteractableState == InteractableState.ProximityState)
        {
            debugMessage = "Button pressedprox";
            DebugText.text = debugMessage;
            flag = 1;
        }

        else if (state.NewInteractableState == InteractableState.ContactState)
        {
            /*debugMessage = "Button pressed";
            DebugText.text = debugMessage;
            contactEvent.Invoke();

            carControl.buttonInteraction();
            flag = 1;*/
            //p.SetActive(false);
            //q.SetActive(true);

            /* debugMessage = "Button pressedcontact";
             DebugText.text = debugMessage;
             contactEvent.Invoke();
             flag = 1;*/

        }
        else if (state.NewInteractableState == InteractableState.ActionState)
        {
            actionEvent.Invoke();
        }
        else
        {
            d = 1;
        }
            

        DebugText.text = debugMessage;
    }

    // Update is called once per frame
    //code added by Asha
    void Update()
    {
        if (flag == 1)
        {
            //rend.sharedMaterial = material[0]; 
            Invoke("changefvalue", 2);

        }

        if (d == 1)
        {
            //rend.sharedMaterial = material[0]; 
            Invoke("changedvalue", 2);

        }
    }
    void changefvalue()
    {

        //p.SetActive(true);
        //rend.sharedMaterial = material[1];
        proximityEvent.Invoke();
        flag = 0;
    }

    void changedvalue()
    {

        //p.SetActive(true);
        //rend.sharedMaterial = material[1];
        defaultEvent.Invoke();
        d = 0;
    }

    

}
