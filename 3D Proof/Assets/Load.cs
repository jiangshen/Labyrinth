using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Forward_A");
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Forward_A");
    }
}
