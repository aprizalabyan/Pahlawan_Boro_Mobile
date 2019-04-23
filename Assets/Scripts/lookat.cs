using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
	public Transform target;
	public float speed;
	public float radius = 3f;

	float distance;
	bool change;

	// Update is called once per frame
	void Update()
	{
		RaycastHit hit;
		Ray looking = new Ray(transform.position, transform.forward);

		Debug.DrawRay(transform.position, transform.forward * 4, Color.red);

		distance = Vector3.Distance(target.position, transform.position);

		if (!change) {
			if (Physics.Raycast (looking, out hit, 4)) {
				if (hit.collider.tag == "Walls") {
					changeRadius ();
				}
				change = false;
			} else {
				radius = 3f;
			}
		}

		if(distance < radius){
				transform.LookAt (target);
				transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
		}
	}

	void changeRadius(){
		change = true;
		radius = 2f;
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
