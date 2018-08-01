using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollCam : MonoBehaviour {
	float m_XOrigin;
	public Text m_ScoreUi;
	public Text m_WavesUI;
	float m_XGameScreen;
	public Button m_StartButton;
	public GameObject m_CameraHolder;
	public EnemyManager m_EM;
	float currentCamX;
	public bool m_ActiveGame;
	public static ScrollCam Instance;
	public float currentenemyMax;
	public PlayerController m_PC;
	// Use this for initialization
	void Start () {
		Instance=this;
		Button btn = m_StartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		m_XGameScreen=15;
		m_XOrigin=-430;
		m_ActiveGame=false;
		currentenemyMax=5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void TaskOnClick()
    {

       m_StartButton.interactable=false;
	   m_StartButton.image.enabled=false;
	   m_ScoreUi.enabled=true;
	   m_WavesUI.enabled=true;
	   m_PC.enabled=true;
	   m_EM.spawnEnemies(5);

	   m_CameraHolder.transform.localPosition = new Vector3( m_XGameScreen, 64, 0);
	   m_ActiveGame=true;
    }
	public void ReturntoMain(){
		m_CameraHolder.transform.localPosition = new Vector3( m_XOrigin, 64, 0);
		m_StartButton.interactable=true;
	   m_StartButton.image.enabled=true;
	}

}
