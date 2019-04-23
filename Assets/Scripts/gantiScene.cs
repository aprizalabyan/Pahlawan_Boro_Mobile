using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gantiScene : MonoBehaviour {
	
	[SerializeField] private string namaScene;
	[SerializeField] private GameObject obj;

	void Start()
	{
		//GameObject player = GameObject.Find ("Karakter");
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider col){
		//if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene (namaScene);
		DontDestroyOnLoad(GameObject.Find("Karakter"));
		DontDestroyOnLoad(GameObject.Find("Main Camera"));
		DontDestroyOnLoad(GameObject.Find("Canvas"));
		Destroy (obj);
		//}
	}
}
