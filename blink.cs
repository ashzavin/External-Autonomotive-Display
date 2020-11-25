using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    public Renderer rend;
    public GameObject player;
    float pos;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.enabled = true;
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        // Find out whether current second is odd or even
        if (player.transform.position.z >= 23.0)
        {
            bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;
            rend.enabled = oddeven;
            //this.rend.enabled = true;
        }
        

        // Enable renderer accordingly
        
    }
}
