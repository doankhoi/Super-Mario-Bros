using UnityEngine;
using System.Collections;

public class Nam : MonoBehaviour {

	public float speedNormal;
	public float speedAttack;
	public float radiusAttack;

	private Vector3 m_position;
	private float m_direction;
	private GameObject m_player;

	public Nam(Vector3 position, float direction){
		this.m_position = position;
		this.m_direction = direction;
		m_player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isNormal ())
			this.transform.position += new Vector3 (m_direction * speedNormal, 0, 0);
		else
			this.transform.position += new Vector3 (m_direction * speedAttack, 0, 0);
	}

	void FixedUpdate(){

	}

	private bool isNormal(){

		return true;
	}

	void Flip(){
		m_direction = - m_direction;
		Vector3 theScale = transform.localScale;
		theScale.x = m_direction;
		transform.localScale = theScale;
	}
	

	void OnCollisionEnter2D(Collision2D col1) {
		if (col1.gameObject.tag == "PipeUp") {
			Flip();
		}
	}
}
