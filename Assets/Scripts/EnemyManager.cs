using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	 public static EnemyManager Instance;
	public GameObject m_EnemyPrefab;
	private GameObject[] m_Enemies;
	private GameObject temp;
	float enemyCount;
	public ScrollCam m_Scrollcam;
	public GameObject m_enemyContainer;

	
	
	
	public void spawnEnemies(float enemies){
		for(int i=0;i<enemies;i++){
		temp=Instantiate(m_EnemyPrefab,new Vector2(Random.Range(-100f,140f),Random.Range(0f,190f)), Quaternion.identity);
			temp.transform.parent=m_enemyContainer.transform;	
		}
	}
	public void clearContainer(){
		foreach (Transform child in transform) {
     	GameObject.Destroy(child.gameObject);
 }
	}
}
