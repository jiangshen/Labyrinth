using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MOvement : MonoBehaviour {
    private const float VERTICAL_ADJUSTMENT = 0.1f; //Makes default tilt 0.3 less.
    private float speed;
    private List<Animator> sprites;

    private Rigidbody rb;
    
    public Text horizontal;
    public Camera deathCamera;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        GetComponentsInChildren<Animator>(sprites);

        speed = 4;
        horizontal.text = "Something";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        bool isMoving = false;
        float moveHorizontal = 0;
        float moveVertical = 0;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");


        if (System.Math.Abs(Input.acceleration.x) > 0.1)
        {
            moveHorizontal = Input.acceleration.x;
            isMoving = true;
        }
        if (System.Math.Abs(Input.acceleration.y + VERTICAL_ADJUSTMENT) > 0.11)
        {
            moveVertical = (Input.acceleration.y + VERTICAL_ADJUSTMENT) * speed;
            isMoving = true;
        }

        if (null != sprites)
        {
            foreach (Animator a in sprites)
            {
                a.speed = isMoving ? 1 : 0;
                //GetComponentsInChildren<Animator>();

            }
        }

        Vector3 movement = new Vector3(0, 0.0f, moveVertical * Time.deltaTime);

        transform.Translate(5f * movement);
        transform.Rotate(0, 2f*moveHorizontal, 0);

        horizontal.text = Input.acceleration.y.ToString();
        //rb.AddTorque(5f*movement);

        //rb.AddForce(movement * 10);
        //rb.MovePosition(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Enemy"))
        {
            //other.gameObject.SetActive(false);
            deathCamera.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
