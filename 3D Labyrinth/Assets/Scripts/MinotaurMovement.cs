using UnityEngine;
using System.Collections;

public class MinotaurMovement : MonoBehaviour {

    private Rigidbody rb;

    private const float SPEED = 4; //Speed thingy thingy

    //Base speeds for straight and turn
    private const float BASE_VERTICAL_SPEED = 5;
    private const float BASE_HORIZONTAL_SPEED = 2;


    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float fHorizontal = 0; //Horizontal Component
        float fVertical = 0; //Vertical Component

        //Take wasd input
        if (Input.GetKey(KeyCode.W))
        {
            fVertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            fVertical = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            fHorizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            fHorizontal = 1;
        }
        

        //Vector for vertical movement
        Vector3 vMovement = new Vector3(0, 0.0f, fVertical * Time.deltaTime);
        //Uses movement vector to move forward and horizontal value to rotate
        transform.Translate(vMovement * BASE_VERTICAL_SPEED);
        transform.Rotate(0, fHorizontal * BASE_HORIZONTAL_SPEED, 0);

    }
}
