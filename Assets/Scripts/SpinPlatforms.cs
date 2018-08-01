using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpinPlatforms : MonoBehaviour {
	Vector3 m_activeVelocity = new Vector3(0, 10, 0);
	public bool m_isStopped = false;
	private Rigidbody2D m_RB;
	public float m_VelocityParam;

	void Start(){
		m_RB = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate(){
		Debug.Log(m_RB.angularVelocity);
		if(!m_isStopped){
			m_RB.angularVelocity = m_VelocityParam;
		}
		else{
			m_RB.angularVelocity = 0;
		}
	}
}
