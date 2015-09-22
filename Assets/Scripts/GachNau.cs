using UnityEngine;
using System.Collections;

public class GachNau : MonoBehaviour {

	private Vector3 m_prevPosition;
	private bool m_isStatic;
	
	
	public float maxDy;
	public float speed;
	
	// Use this for initialization
	void Start () {
		m_prevPosition = this.transform.position;
		m_isStatic = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!m_isStatic) {
			this.transform.position += new Vector3(0.0f, speed*Time.deltaTime, 0.0f);
			if((this.transform.position.y - m_prevPosition.y) >= maxDy){
				speed = -speed;
			}
			
			if(this.transform.position.y <= m_prevPosition.y){
				m_isStatic = true;
				speed = -speed;
				this.transform.position = m_prevPosition;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col1) {
		Vector3 objPos = col1.gameObject.transform.position;
		if ((col1.gameObject.tag == "Player") && (objPos.y < this.transform.position.y)&&(col1.gameObject.tag != "groundCheck")) {
			m_isStatic = false;
		}
	}
}
