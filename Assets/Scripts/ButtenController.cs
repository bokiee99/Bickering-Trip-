using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtenController : MonoBehaviour
{
	public void SwitchScene()
	{
		SceneManager.LoadScene("Plain Area");
	}
	public void QuitGame()
	{
        Application.Quit();
	}
}
