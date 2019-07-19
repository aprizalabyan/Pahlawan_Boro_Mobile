using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DitzeGames.MobileJoystick;

namespace DitzeGames.MobileJoystick{
	public class kontrol_mobile : MonoBehaviour{
		
		protected Joystick Joystick;
		protected Button Button;
		protected TouchField TouchField;

		[SerializeField] private float m_moveSpeed = 2;
		[SerializeField] private float m_turnSpeed = 200;
		[SerializeField] private float m_jumpForce = 4;
		[SerializeField] private Animator m_animator;
		[SerializeField] private Rigidbody m_rigidBody;

		private float m_currentV1 = 0;
		private float m_currentV2 = 0;
		private float m_currentH = 0;

		private readonly float m_interpolation = 10;
		private readonly float m_walkScale = 0.33f;
		private readonly float m_backwardsWalkScale = 0.16f;
		private readonly float m_backwardRunScale = 0.66f;

		private bool m_wasGrounded;
		//private Vector3 m_currentDirection = Vector3.zero;

		private float m_jumpTimeStamp = 0;
		private float m_minJumpInterval = 0.25f;

		private float v1;
		private float v2;
		private float h;

		private bool m_isGrounded;
		private List<Collider> m_collisions = new List<Collider>();

		private void OnCollisionEnter(Collision collision)
		{
			ContactPoint[] contactPoints = collision.contacts;
			for(int i = 0; i < contactPoints.Length; i++)
			{
				if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0f)
				{
					if (!m_collisions.Contains(collision.collider)) {
						m_collisions.Add(collision.collider);
					}
					m_isGrounded = true;
				}
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			ContactPoint[] contactPoints = collision.contacts;
			bool validSurfaceNormal = false;
			for (int i = 0; i < contactPoints.Length; i++)
			{
				if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0f)
				{
					validSurfaceNormal = true; break;
				}
			}

			if(validSurfaceNormal)
			{
				m_isGrounded = true;
				if (!m_collisions.Contains(collision.collider))
				{
					m_collisions.Add(collision.collider);
				}
			} else
			{
				if (m_collisions.Contains(collision.collider))
				{
					m_collisions.Remove(collision.collider);
				}
				if (m_collisions.Count == 0) { m_isGrounded = false; }
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if(m_collisions.Contains(collision.collider))
			{
				m_collisions.Remove(collision.collider);
			}
			if (m_collisions.Count == 0) { m_isGrounded = false; }
		}

		// Use this for initialization
		void Awake ()
		{
			Joystick = FindObjectOfType<Joystick>();
			Button = FindObjectOfType<Button>();
			TouchField = FindObjectOfType<TouchField>();
		}

		// Update is called once per frame
		void Update () {
			m_animator.SetBool("Grounded", m_isGrounded);
			m_wasGrounded = m_isGrounded;

			/*
			transform.position = new Vector3(transform.position.x + Joystick.AxisNormalized.x * Time.deltaTime * 3f, Button.Pressed ? 2 : 1, transform.position.z + Joystick.AxisNormalized.y * Time.deltaTime * 3f);
			transform.Rotate(Vector3.up, TouchField.TouchDist.x);
			transform.Rotate(Vector3.left, TouchField.TouchDist.y);
			*/

			v1 = Joystick.AxisNormalized.y;
			v2 = Joystick.AxisNormalized.x;
			h = TouchField.TouchDist.x;

			/*bool walk = Button.Pressed;

			if (v1 < 0) {
				if (walk) {
					v1 *= m_backwardsWalkScale;
				} else {
					v1 *= m_backwardRunScale;
				}
			} else if (walk) {
				v1 *= m_walkScale;
			} else if (v2 > 0) {
				v2 *= m_backwardRunScale;
			}*/

			m_currentV1 = Mathf.Lerp(m_currentV1, v1, Time.deltaTime * m_interpolation);
			m_currentV2 = Mathf.Lerp(m_currentV2, v2, Time.deltaTime * m_interpolation);
			m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

			transform.position += transform.forward * m_currentV1 * m_moveSpeed * Time.deltaTime;
			transform.position += transform.right * m_currentV2 * m_moveSpeed * Time.deltaTime;
			//transform.position = new Vector3 (transform.position.x * m_currentV2 * m_moveSpeed * Time.deltaTime, 0, 0);
			transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

			m_animator.SetFloat("MoveSpeed", m_currentV1);

			JumpingAndLanding();
		}
	
		private void JumpingAndLanding()
		{
			bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

			if (jumpCooldownOver && m_isGrounded && Button.Pressed)
			{
				m_jumpTimeStamp = Time.time;
				m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
			}

			if (!m_wasGrounded && m_isGrounded)
			{
				m_animator.SetTrigger("Land");
			}

			if (!m_isGrounded && m_wasGrounded)
			{
				m_animator.SetTrigger("Jump");
			}
		}
	}
}