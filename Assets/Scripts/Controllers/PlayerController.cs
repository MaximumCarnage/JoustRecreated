using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D m_RB;
	public float m_Speed = 10;
	public float m_lives;
	private Animator m_anim;
	public float m_Score;
	private AudioSource m_source;
	public AudioClip m_NewWave;
	public AudioClip m_Flapsfx;
	public AudioClip m_Crashsfk;
	public AudioClip m_Killsfk;
	public GameManager m_GameManager;
	public EnemyManager m_EM;
	public bool m_onGround;
	public Text m_ScoreUI;
	public Text m_waveUI;
	public bool m_ded;
	public ScrollCam m_CamScroll;
	public static PlayerController Instance;
	public  float enemykilled;
	private float currentwave;
	void Start(){
		Instance=this;
		m_RB = GetComponent<Rigidbody2D>();
		m_anim = GetComponent<Animator>();
		m_source=GetComponent<AudioSource>();
		m_lives=3;
		m_ded=false;
		enemykilled=0;
		currentwave=1;
	}
	 void FixedUpdate(){
		if(Physics2D.Raycast(transform.position+new Vector3(0,-12,0), -Vector2.up,1f))
		{
			m_onGround=true;
			GetComponent<BoxCollider2D>().enabled=true;
		}
			else if(!Physics2D.Raycast(transform.position+new Vector3(0,-12,0), -Vector2.up,1f)){
				m_onGround=false;
				
			}
				
	 }
	void Update(){
		 m_ScoreUI.text="Score: "+m_Score;
		 m_waveUI.text="Waves: "+currentwave;
		if(m_onGround){
			m_anim.SetBool("OnGround",true);
			
		}
		else{
			m_anim.SetBool("OnGround",false);
		}
		if(Input.GetKey(KeyCode.Space)){
			m_anim.SetBool("Flap", false); 	
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			m_RB.velocity = new Vector3(0,2,0) * m_Speed;
			m_source.PlayOneShot(m_Flapsfx,3f);
			m_anim.SetBool("Flap", true);	
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.localScale=new Vector3(1, 1, 1);;
			m_RB.velocity = new Vector2(1*40, m_RB.velocity.y);
			if(m_onGround){
				m_anim.SetInteger("Speed",2);
			}
			else if(!m_onGround){
				m_anim.SetInteger("Speed",0);
			}
			
			
		}
		if(Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow))
		{
				m_anim.SetInteger("Speed",0);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.localScale=new Vector3(-1, 1, 1);
			m_RB.velocity = new Vector2(-1*40, m_RB.velocity.y);
			if(m_onGround){
				m_anim.SetInteger("Speed",2);
			}
			else if(!m_onGround){
				m_anim.SetInteger("Speed",0);
			}
			 
		}
		if( transform.position.x < -100 ) {
		 	transform.position = new Vector3(145,transform.position.y, transform.position.z);
		}
		 else if(  transform.position.x>145){
		  transform.position = new Vector3(-100,transform.position.y, transform.position.z);
		 }
	 }
	 void OnCollisionEnter2D(Collision2D col){
		 
		  if(col.gameObject.tag == "Ground"){
		 	
		 	m_source.clip=m_Crashsfk;
		 	m_source.Play();
		  }
		 if(col.gameObject.tag == "Lava"){
			 m_source.PlayOneShot(m_Killsfk,3f);
			 m_lives--;
			 transform.position=new Vector2(73,148);
			 if(m_lives<=0){
				m_ded=true;
				transform.position=new Vector2(-73,148);
				m_Score=0;
				m_lives=3;
				enemykilled=0;
				m_EM.clearContainer();
				
				this.enabled=false;
				m_CamScroll.ReturntoMain();
				

			 }
		 }
		 if(col.gameObject.tag == "Enemy"){
			 //Vector2.Dot(other.gameObject.transform.position,gameObject.transform.position);
			 m_source.PlayOneShot(m_Killsfk,3f);
			 Destroy(col.gameObject);
			 enemykilled++;
			 m_Score+=15;
			
			 if(enemykilled==m_CamScroll.currentenemyMax){
				m_CamScroll.currentenemyMax+=2;
				m_EM.spawnEnemies(m_CamScroll.currentenemyMax);
				m_source.PlayOneShot(m_NewWave,3f);
				
				currentwave++;
				enemykilled=0;
			 }
		 }
	 }
	
	
	
	
}
