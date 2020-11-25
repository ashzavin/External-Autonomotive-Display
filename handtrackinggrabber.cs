using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class handtrackinggrabber : OVRGrabber
{
    // Start is called before the first frame update
    private Hand hand;
    public float pinchThresh = 0.7f;

    protected override void Start()
    {
        base.Start();
        hand=GetComponent<Hand>();
    }
    public override void Update()
    {
        base.Update();
        checkIndexPinch();
    }
    void checkIndexPinch()
    {
        float pinchStrength = hand.PinchStrength(OVRPlugin.HandFinger.Index);
        bool isPinching = pinchStrength > pinchThresh;
        if (!m_grabbedObj && isPinching && m_grabCandidates.Count>0)
        {
            GrabBegin();
        }
   
        else if (m_grabbedObj && !isPinching)
            GrabEnd();
       
    }
}
