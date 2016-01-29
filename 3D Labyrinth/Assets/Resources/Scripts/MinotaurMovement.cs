using UnityEngine;
using System.Collections;

public class MinotaurMovement : MonoBehaviour {

    private Rigidbody rb;

    private const float SPEED = 4; //Speed thingy thingy

    //Base speeds for straight and turn
    private const float BASE_VERTICAL_SPEED = 5;
    private const float BASE_HORIZONTAL_SPEED = 4;
    private const float BASE_COOLDOWN = 5;
    private const float BASE_DASH_DECAY = 0.25f;
    private const float BASE_DASH_MULTIPLIER = 4f;

    private float m_fCooldown;
    public AudioClip dashSound;

    private float m_fDash;
    //private float fVerticalAxis = 0;
    //private float fHorizontalAxis = 0;

            
    void Start () {
        rb = GetComponent<Rigidbody>();
        m_fDash = 1;
        m_fCooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float fHorizontal = 0; 
        float fVertical = 0; //Vertical Component



        //Check super key
        if (Input.GetKeyDown(KeyCode.Space) && m_fCooldown <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(dashSound);
            Dash();
        }


        //take WASD input
        fVertical = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        fHorizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
        
        //Vector for vertical movement
        //Vector3 vMovement = new Vector3(0, 0.0f, (fVertical * m_fDash) * Time.deltaTime);

        //Uses movement vector to move forward and horizontal value to rotate
		rb.velocity = transform.forward * fVertical * BASE_VERTICAL_SPEED * m_fDash;
        transform.Rotate(0, BASE_HORIZONTAL_SPEED * fHorizontal, 0);

        //Decrement dash
        if (m_fDash > 1)
        {
            m_fDash -= BASE_DASH_DECAY;
            if (m_fDash < 1)
            {
                m_fDash = 1;
            }
        }
        //Decrement cooldown
        if (m_fCooldown > 0)
        {
            m_fCooldown -= Time.deltaTime;
        }

    }

    void Dash()
    {
        m_fDash = BASE_DASH_MULTIPLIER;
        m_fCooldown = BASE_COOLDOWN;
    }
}
