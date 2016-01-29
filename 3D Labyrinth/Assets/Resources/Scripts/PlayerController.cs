using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    public Camera redDeathCamera;
    public Camera cyanDeathCamera;

    private const float VERTICAL_ADJUSTMENT = 0.1f; //Makes default tilt less.
    private const float ACCELEROMETER_SPEED = 4; //Speed thingy thingy

    //Base speeds for straight and turn
    private const float BASE_VERTICAL_SPEED = 6;
    private const float BASE_HORIZONTAL_SPEED = 4;

    //Dictionary of color of player to control keys
    private Dictionary<string, KeyCode[]> aKeyBindings;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        aKeyBindings = new Dictionary<string, KeyCode[]>();
        aKeyBindings.Add("Red", new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow});
        aKeyBindings.Add("Cyan", new KeyCode[] { KeyCode.I, KeyCode.K, KeyCode.L, KeyCode.J });
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float fHorizontal = 0; //Horizontal Component
        float fVertical = 0; //Vertical Component

        //Take axis inputs
        //fHorizontal = Input.GetAxis("Horizontal");
        //fVertical = Input.GetAxis("Vertical");



        //Take accelerometer inputs
        //if (System.Math.Abs(Input.acceleration.x) > 0.1)
        //{
        //    fHorizontal = Input.acceleration.x;
        //}
        //if (System.Math.Abs(Input.acceleration.y + VERTICAL_ADJUSTMENT) > 0.11)
        //{
        //    fVertical = (Input.acceleration.y + VERTICAL_ADJUSTMENT) * ACCELEROMETER_SPEED;
        //}



        //Get inputs
        if (gameObject.tag.Contains("Red"))
        {
            fVertical = (Input.GetKey(aKeyBindings["Red"][0]) ? 1 : 0) + (Input.GetKey(aKeyBindings["Red"][1]) ? -1 : 0);
            fHorizontal = (Input.GetKey(aKeyBindings["Red"][2]) ? 1 : 0) + (Input.GetKey(aKeyBindings["Red"][3]) ? -1 : 0);
        }
        else if (gameObject.tag.Contains("Cyan"))
        {
            fVertical = (Input.GetKey(aKeyBindings["Cyan"][0]) ? 1 : 0) + (Input.GetKey(aKeyBindings["Cyan"][1]) ? -1 : 0);
            fHorizontal = (Input.GetKey(aKeyBindings["Cyan"][2]) ? 1 : 0) + (Input.GetKey(aKeyBindings["Cyan"][3]) ? -1 : 0);
        }


        //Vector for vertical movement
        //Vector3 vMovement = new Vector3(0, 0.0f, fVertical * Time.deltaTime);
        //Uses movement vector to move forward and horizontal value to rotate
        //transform.Translate(BASE_VERTICAL_SPEED * vMovement);
        rb.velocity = transform.forward * BASE_VERTICAL_SPEED * fVertical;
        transform.Rotate(0, BASE_HORIZONTAL_SPEED * fHorizontal, 0);

    }

    //On trigger
    void OnCollisionEnter(Collision collision)
    {
        //If it is an enemy, you die and the camera is now on top.
        if (collision.gameObject.tag.Contains("Minotaur"))
        {
            if (gameObject.tag.Contains("Red"))
            {
                redDeathCamera.gameObject.SetActive(true);
            }
            else if (gameObject.tag.Contains("Cyan"))
            {
                cyanDeathCamera.gameObject.SetActive(true);
            }
            gameObject.SetActive(false);
            
        }
    }
}
