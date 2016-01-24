using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour
{

    private Rigidbody rb;

    //laser shot
    public Rigidbody projectile;

    private const float SPEED = 4; //Speed thingy thingy

    //Base speeds for straight and turn
    private const float BASE_VERTICAL_SPEED = 5;
    private const float BASE_HORIZONTAL_SPEED = 2;
    private const float BASE_BULLET_SPEED = 10;
    private const float BASE_COOLDOWN = 5;

    private float m_fCooldown;

    private float m_fDash;
    //private float fVerticalAxis = 0;
    //private float fHorizontalAxis = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_fDash = 1;
        m_fCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float fHorizontal = 0;
        float fVertical = 0; //Vertical Component


        //Check super key
        if (Input.GetKeyDown(KeyCode.Space) && m_fCooldown <= 0)
        {
            Shoot();
        }


        //take WASD input
        fVertical = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        fHorizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);

        //Vector for vertical movement
        Vector3 vMovement = new Vector3(0, 0.0f, (fVertical * m_fDash) * Time.deltaTime);

        //Uses movement vector to move forward and horizontal value to rotate
        rb.velocity = transform.forward * BASE_VERTICAL_SPEED * fVertical;
        transform.Rotate(0, BASE_HORIZONTAL_SPEED * fHorizontal, 0);

        //Decrement cooldown
        if (m_fCooldown > 0)
        {
            m_fCooldown -= Time.deltaTime;
        }


    }

    void Shoot()
    {
        Rigidbody laser;
        laser = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as Rigidbody;
        Quaternion qRotation = Quaternion.AngleAxis(90, new Vector3(transform.forward.z, transform.forward.y, transform.forward.x));
        laser.transform.rotation = qRotation;
        laser.velocity = transform.TransformDirection(Vector3.forward * BASE_BULLET_SPEED);

        m_fCooldown = BASE_COOLDOWN;

    }
}
