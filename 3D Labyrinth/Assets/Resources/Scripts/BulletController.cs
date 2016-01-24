using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    private Vector3 velocity;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        velocity = rb.velocity;
        Debug.Log(velocity);
	}


    void OnCollisionEnter(Collision oCollision)
    {
        
        if (oCollision.gameObject.tag.Contains("Player"))
        {
            //oCollision.gameObject.transform.Translate(velocity);
            oCollision.gameObject.transform.Translate(-1 * velocity / 2f, Space.World);
        }
        gameObject.SetActive(false);
    }
}
