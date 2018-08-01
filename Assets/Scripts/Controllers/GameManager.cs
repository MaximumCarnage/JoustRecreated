using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public Text m_ScoreUI;
	public Text m_WaveNum;
	public float m_lives;
	public float m_Score;

	public ScrollCam m_CamScroll;

	private GameObject m_PlayerPrefab;
	public GameObject m_EnemyPrefab;
	public Vector3 m_playerSpawn;
	public bool dedplayer;
	public PlayerController m_Pc;


	void Start () {
		
		m_Score=0;
		m_playerSpawn = new Vector3(-68,142,0);
		
		
	}
	
	
	void Update () {
		
		
		 
		
		
	}

}
