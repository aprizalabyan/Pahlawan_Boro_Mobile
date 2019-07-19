using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLoad : MonoBehaviour
{
	[SerializeField] private GameObject obj;
	private GameObject obj1;
	private GameObject obj2;
	private GameObject obj3;
	private GameObject obj4;
	private GameObject obj5;

    // Start is called before the first frame update
    void Start()
    {
		obj1 = GameObject.Find("Karakter");
		obj2 = GameObject.Find("Main Camera");
		obj3 = GameObject.Find("Joystick");
		obj4 = GameObject.Find("Touchfield");
		obj5 = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {
		

    }

	private void OnTriggerEnter(Collider col){
		Destroy(obj1);
		//Destroy(obj2);
		Destroy(obj3);
		Destroy(obj4);
		Destroy(obj5);
	}
}
