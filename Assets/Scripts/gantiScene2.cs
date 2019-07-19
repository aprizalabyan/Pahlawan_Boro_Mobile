using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gantiScene2 : MonoBehaviour
{
	[SerializeField] private string namaScene;
	//[SerializeField] private GameObject obj;

	private GameObject player;

	void Awake()
	{
		player = GameObject.Find ("Karakter");
	}

	void OnTriggerEnter(Collider col)
	{
		SceneManager.LoadScene (namaScene);
		DontDestroyOnLoad(GameObject.Find("MainCamera"));
		DontDestroyOnLoad(GameObject.Find("Canvas"));
		Destroy (player);
	}
}
