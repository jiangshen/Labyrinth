using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float left = Input.GetAxis("Horizontal");
        float up = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(left, up, 0) * 0.2f);
        //rb.AddForce(new Vector3(left, up, 0) * 5);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * 500);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(1, 0, 0) * 500);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {}
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

        }

    }

    void OnCollisionEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
    }
}
