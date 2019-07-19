using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
	private GameObject[] GameObjects;

    // Start is called before the first frame update
    void Awake()
    {
		GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
    }

	public void menu(){
		SceneManager.LoadScene("MainMenu");
		for (int i = 0; i < GameObjects.Length; i++){
			Destroy(GameObjects[i]);
		}
	}
}
