using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour {

	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offsetPosition;

	private void LateUpdate(){
		if (target == null){
			Debug.LogWarning("Missing target ref !", this);
			return;
		}
		transform.position = target.TransformPoint(offsetPosition);
		transform.rotation = target.rotation;
	}
}
