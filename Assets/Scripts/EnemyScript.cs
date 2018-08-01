using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	Vector2 Randomvelocity;
	Rigidbody2D m_RB;
	Vector2 m_pos;
	float m_patrolPath;
	// Use this for initialization
	void Start () {
		m_RB=GetComponent<Rigidbody2D>();
		m_patrolPath=Random.Range(1f,5f);
	}
	
	// Update is called once per frame
	void Update () {
		m_pos=transform.position;
		
		if( m_pos.x < -100f ) {
		 	m_pos = new Vector2(145f,m_pos.y);
		}
		 else if(  m_pos.x>145){
		  m_pos = new Vector3(-100f,m_pos.y);
		 }
		m_RB.velocity+=new Vector2(0,0.2f) ;
			
			
				
			
		
		 
	}
	
}
