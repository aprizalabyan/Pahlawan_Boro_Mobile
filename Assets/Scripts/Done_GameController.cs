using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    //public Text restartText;
	public Text selesaiText;
	//public Button restartButton;
	public GameObject restartButton;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        //restartText.text = "";
		restartButton.SetActive(false);
    }

    void Update()
    {
		if (gameOver)
		{
			//restartText.text = "Tekan 'R' untuk ulang kembali";
			restartButton.SetActive(true);
			selesaiText.text = "Selesai";
			restart = true;
		}
		/*
        if (restart)
        {
            if (restartButton.Pressed)
            {
                SceneManager.LoadScene("Scene1");
				Destroy (GameObject.Find ("Canvas"));
            }

			//gameOver = false;
        }
		*/
		//restart = false;
    }

	private void OnTriggerEnter(Collider col){
		//trigger = true;
		gameOver = true;
	}
}