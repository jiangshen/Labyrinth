using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision oCollision)
    {
        gameObject.SetActive(false);
        if (oCollision.gameObject.tag.Contains("Player"))
        {
            oCollision.gameObject.transform.Translate(oCollision.relativeVelocity / 2);
        }
    }
}
