using UnityEngine;
using System.Collections;

public class SphereMovement : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(fHorizontal, 0, fVertical) * 10);
    }
}
