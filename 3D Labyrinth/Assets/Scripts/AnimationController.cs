using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //If it is a player
        if (gameObject.tag.Contains("Player"))
        {
            Animator a = GetComponent<Animator>();
            //If player is not moving
            if (!(Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow)))
            {
                //Stop animation
                //a.Stop();
                a.speed = 0;
            }
            else
            {
                a.speed = 0;
            }
        }
        
	    
	}
}
