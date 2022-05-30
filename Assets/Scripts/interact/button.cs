using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : interactable
{
    private GameObject distractable;
    public int timeDrain = 1;
    public int time = 10;

    void Start()
    {
        
    }
    public override void interact()
    {
        //distractable = GameObject.Find("distractable");
        distractable distractable = GetComponent<distractable>();
        if (distractable.activated == true)
        {
            time - timeDrain
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
