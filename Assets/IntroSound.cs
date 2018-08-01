using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSound : MonoBehaviour {
	AudioSource m_source;
	public AudioClip m_startup;
	// Use this for initialization
	void Start () {
		m_source=GetComponent<AudioSource>();
		m_source.PlayOneShot(m_startup,3f);
	}
	
	// Update is called once per frame
	
}
