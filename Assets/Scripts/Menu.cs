using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public void NewGame()
	{
		Application.LoadLevel (1);
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
