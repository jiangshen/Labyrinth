using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinConditions : MonoBehaviour {

	private int m_nKillCount;
	public Text txtAnnouncement;
	public int m_nGoal;

	private string m_szMessage;
	private float m_fNotifTimer;
	private float m_fDeathTimer;

	private const float DEATH_TIMER = 10;
	// Use this for initialization
	void Start () {
		m_nKillCount = 0;
		m_szMessage = "";
		m_fNotifTimer = 0;
		m_nGoal = 2;
		m_fDeathTimer = DEATH_TIMER;
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

		if (m_fDeathTimer > 0)
		{
			m_fDeathTimer -= Time.deltaTime;
		} else {
			m_szMessage = "Time has run out!";
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
			m_szMessage = "Minotaur has won!";
		}


	}
}
