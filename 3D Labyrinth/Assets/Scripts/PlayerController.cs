using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Camera deathCamera;

    //private Rigidbody rb;
    //public Text keyDown;

    private const float VERTICAL_ADJUSTMENT = 0.1f; //Makes default tilt less.
    private const float ACCELEROMETER_SPEED = 4; //Speed thingy thingy

    //Base speeds for straight and turn
    private const float BASE_VERTICAL_SPEED = 6;
    private const float BASE_HORIZONTAL_SPEED = 2;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float fHorizontal = 0; //Horizontal Component
        float fVertical = 0; //Vertical Component
        bool isMoving = false; //If moving

        //Take axis inputs
        fHorizontal = Input.GetAxis("Horizontal");
        fVertical = Input.GetAxis("Vertical");
        //keyDown.text = "Horizontal: " + fHorizontal.ToString() + "Vertical: " + fVertical.ToString();

        //Take accelerometer inputs
        if (System.Math.Abs(Input.acceleration.x) > 0.1)
        {
            fHorizontal = Input.acceleration.x;
            isMoving = true;
        }
        if (System.Math.Abs(Input.acceleration.y + VERTICAL_ADJUSTMENT) > 0.11)
        {
            fVertical = (Input.acceleration.y + VERTICAL_ADJUSTMENT) * ACCELEROMETER_SPEED;
            isMoving = true;
        }

        //Vector for vertical movement
        Vector3 vMovement = new Vector3(0, 0.0f, fVertical * Time.deltaTime);
        //Uses movement vector to move forward and horizontal value to rotate
        transform.Translate(BASE_VERTICAL_SPEED * vMovement);
        transform.Rotate(0, BASE_HORIZONTAL_SPEED * fHorizontal, 0);

    }

    //On trigger
    void OnCollisionEnter(Collision collision)
    {
        //If it is an enemy, you die and the camera is now on top.
        if (collision.gameObject.tag.Contains("Minotaur"))
        {
            //other.gameObject.SetActive(false);
            deathCamera.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
