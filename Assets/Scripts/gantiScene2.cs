using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gantiScene2 : MonoBehaviour
{
	[SerializeField] private string namaScene;

    // Start is called before the first frame update
    void Start()
    {
		DontDestroyOnLoad(GameObject.Find("MainCamera"));
		DontDestroyOnLoad(GameObject.Find("Player"));
		DontDestroyOnLoad(GameObject.Find("Canvas"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider col){
		SceneManager.LoadScene (namaScene);
	}
}
