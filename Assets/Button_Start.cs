using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour {

	public void ButtonStart()
	{
		SceneManager.LoadScene ("_Scene_0");
	}

	public void ButtonX()
	{
		Application.Quit ();
	}
}
