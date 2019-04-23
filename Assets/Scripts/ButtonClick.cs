using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
	
	//[SerializeField] private string namaScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	public void ChangeScene(string namaScene){
		SceneManager.LoadScene (namaScene);
	}
}
