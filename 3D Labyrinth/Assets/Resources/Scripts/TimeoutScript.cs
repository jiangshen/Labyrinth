using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeoutScript : MonoBehaviour {

    public Camera deathCamera;
    public Camera victoryCamera;

    public Button btnReturn;

    public Text txtLife;
    public Text txtAnnouncement;

    public AudioClip overSound;

    private float m_fDeathTimer;
    private const float DEATH_TIMER = 90;

    


    // Use this for initialization
    void Start () {
        m_fDeathTimer = DEATH_TIMER;
    }

    void UpdateTimer()
    {
        if (gameObject.tag.Contains("Enemy"))
        {
            txtLife.text = m_fDeathTimer > 0 ? m_fDeathTimer.ToString() : "0";
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (m_fDeathTimer > 0)
        {
            m_fDeathTimer -= Time.deltaTime;
            UpdateTimer();
        }
        else
        {
            UpdateTimer();
            
            if (gameObject.tag.Contains("Enemy"))
            {
                deathCamera.gameObject.SetActive(true);
                btnReturn.gameObject.SetActive(true);
                txtAnnouncement.text = "Time has run out!";

                GetComponent<AudioSource>().PlayOneShot(overSound);
            }
            else if (gameObject.tag.Contains("Player"))
            {
                victoryCamera.gameObject.SetActive(true);
            }
            gameObject.SetActive(false);

        }
    }
}
