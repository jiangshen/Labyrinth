using UnityEngine;
using System.Collections;

public class MOVEBACK : MonoBehaviour
{

    public float speed = 2;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //float moveHorizontal = Input.acceleration.x;
        //float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3(0, 0.0f, -1);

        rb.AddForce(movement * speed);

    }
}
