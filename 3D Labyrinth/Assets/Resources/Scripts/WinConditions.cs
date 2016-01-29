using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinConditions : MonoBehaviour {

	private int m_nKillCount;
	public Text txtAnnouncement;
    
    public Button btnReturn;
	public int m_nGoal;
    public Camera deathCamera;
    public Camera victoryCamera;

	private string m_szMessage;
	private float m_fNotifTimer;
	//private float m_fDeathTimer;

	//private const float DEATH_TIMER = 60;
	// Use this for initialization
	void Start () {
		m_nKillCount = 0;
		m_szMessage = "";
		m_fNotifTimer = 0;
		m_nGoal = 2;
		//m_fDeathTimer = DEATH_TIMER;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_fNotifTimer > 0) {
			m_fNotifTimer -= Time.deltaTime;
		}
		else
		{
			m_szMessage = "";
		}

		

		txtAnnouncement.text = m_szMessage;
	}

	void OnCollisionEnter(Collision oCollide)
	{
		if (oCollide.gameObject.tag.Contains("Player"))
		{
			m_nKillCount++;
			m_szMessage = "You have defeated a player";
			m_fNotifTimer = 2;
		}

		if (m_nKillCount >= m_nGoal)
		{
            //VIECTORY
			m_szMessage = "Minotaur has won!";
            btnReturn.gameObject.SetActive(true);
            gameObject.SetActive(false);
            victoryCamera.gameObject.SetActive(true);

		}


	}
}
