using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	private GameObject[] GameObjects;

    // Start is called before the first frame update
    void Awake()
    {
		GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
    }

	public void restart(){
		SceneManager.LoadScene("Scene1");
		for (int i = 0; i < GameObjects.Length; i++){
			Destroy(GameObjects[i]);
		}

		AdmobHandler.Instance.ShowIntersAd();
	}
}
