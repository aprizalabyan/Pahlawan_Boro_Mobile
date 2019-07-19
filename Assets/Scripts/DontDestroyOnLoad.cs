using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	private void OnTriggerEnter(Collider col)
	{
		DontDestroyOnLoad(GameObject.Find("Karakter"));
		//DontDestroyOnLoad(GameObject.Find("Main Camera"));
		DontDestroyOnLoad(GameObject.Find("Canvas"));
	}
}
