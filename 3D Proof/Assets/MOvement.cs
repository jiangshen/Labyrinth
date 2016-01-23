using UnityEngine;
using System.Collections;

public class MOvement : MonoBehaviour {
    private Rigidbody rb;
    private float speed;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 4;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //float moveHorizontal = Input.acceleration.x;
        //float moveVertical = Input.acceleration.y * speed;

        Vector3 movement = new Vector3(0, 0.0f, moveVertical * Time.deltaTime);

        transform.Translate(5f * movement);
        transform.Rotate(0, 2f*moveHorizontal, 0);
        //rb.AddTorque(5f*movement);

        //rb.AddForce(movement * 10);
        //rb.MovePosition(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
