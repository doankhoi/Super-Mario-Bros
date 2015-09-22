using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 4f;
	public float jumpForce = 50f;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	private bool faceRight = true;
	private bool m_grounded = false;
	private float groundRadius = 0.2f;
	private Rigidbody2D m_rigidbody2D;
	private Animator m_animator;
	
	void Awake()
	{
		m_rigidbody2D = GetComponent<Rigidbody2D> ();
		m_animator = GetComponent<Animator> ();
	}

	void Update(){
		if(m_grounded && Input.GetKeyDown(KeyCode.Space))
		{
			m_animator.SetBool("Ground", false);
			m_rigidbody2D.AddForce(new Vector2(0,jumpForce));
		}
	}

	void FixedUpdate (){

		m_grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		m_animator.SetBool ("Ground", m_grounded);
		m_animator.SetFloat ("vSpeed", m_rigidbody2D.velocity.y);

		if (!m_grounded)
			return;

		float move = Input.GetAxis ("Horizontal");
		m_animator.SetFloat ("Speed", Mathf.Abs(move));

		m_rigidbody2D.velocity = new Vector2(move*maxSpeed, m_rigidbody2D.velocity.y);
		if (move > 0 && !faceRight) {
			Flip();
		}else if(move < 0 && faceRight){
			Flip();
		}
	}

	void Flip(){
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D col1) {

	}
	
}
