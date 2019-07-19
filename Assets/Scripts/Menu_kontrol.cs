using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_kontrol : MonoBehaviour
{

	public GameObject objectDisable1;
	public GameObject objectDisable2;
	public GameObject objectEnable;
	public static bool disabled = false;
	//public About about;

    // Start is called before the first frame update
    void Start()
    {
		//Button = GameObject.Find ("About");
    }

    // Update is called once per frame
    void Update()
    {
		
		if(disabled){
			objectDisable1.SetActive(false);
			objectDisable2.SetActive(false);
		}
		else{
			objectDisable1.SetActive(true);
			objectDisable2.SetActive(true);
		}
    }
}
