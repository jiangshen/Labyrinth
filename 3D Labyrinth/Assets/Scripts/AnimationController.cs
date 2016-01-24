using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationController : MonoBehaviour {


    private Dictionary<string, KeyCode[]> aKeyBindings;


    // Use this for initialization
    void Start () {
        aKeyBindings = new Dictionary<string, KeyCode[]>();
        aKeyBindings.Add("Red", new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow });
        aKeyBindings.Add("Cyan", new KeyCode[] { KeyCode.I, KeyCode.K, KeyCode.L, KeyCode.J });
        aKeyBindings.Add("Minotaur", new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.A });
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Animator a = GetComponent<Animator>();


        //If it is a red
        if (gameObject.tag.Contains("Red"))
        {
            //If player is not moving
            if (!(Input.GetKey(aKeyBindings["Red"][0]) ||
            Input.GetKey(aKeyBindings["Red"][1]) ||
            Input.GetKey(aKeyBindings["Red"][2]) ||
            Input.GetKey(aKeyBindings["Red"][3])))
            {
                a.speed = 0;
            }
            else
            {
                a.speed = 1;
            }
        }
        else if (gameObject.tag.Contains("Minotaur")) //If minotaur
        {
            //If player is not moving
            if (!(Input.GetKey(aKeyBindings["Minotaur"][0]) ||
            Input.GetKey(aKeyBindings["Minotaur"][1]) ||
            Input.GetKey(aKeyBindings["Minotaur"][2]) ||
            Input.GetKey(aKeyBindings["Minotaur"][3])))
            {
                a.speed = 0;
            }
            else
            {
                a.speed = 1;
            }
        }
        else if (gameObject.tag.Contains("Cyan")) //If cyan
        {
            //If player is not moving
            if (!(Input.GetKey(aKeyBindings["Cyan"][0]) ||
            Input.GetKey(aKeyBindings["Cyan"][1]) ||
            Input.GetKey(aKeyBindings["Cyan"][2]) ||
            Input.GetKey(aKeyBindings["Cyan"][3])))
            {
                a.speed = 0;
            }
            else
            {
                a.speed = 1;
            }
        }


    }
}
