using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	[SerializeField] private Animator m_animator;
	[SerializeField] private Rigidbody m_rigidBody;

	public GameObject[] waypoints;
	int current = 0;
	public float speed;
	float rotSpeed = 1f;
	float wpRadius = 0.1f;
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(waypoints[current].transform.position, transform.position) < wpRadius){
			current++;
			//current = Random.Range(0, waypoints.Length);
			if (current >= waypoints.Length) {
				current = 0;
			}
		}
		transform.position = Vector3.MoveTowards (transform.position, waypoints [current].transform.position, Time.deltaTime * speed);
		//transform.LookAt (waypoints[current].transform.position);

		Quaternion rotation = Quaternion.LookRotation(waypoints[current].transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);
	}

}
