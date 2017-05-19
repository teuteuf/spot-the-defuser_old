using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public enum Screens { HomeScreen, ConnectionScreen, GameScreen, ErrorScreen };

	public Dictionary<Screens, string> screensDictionary;

	private void Start()
	{
		screensDictionary = new Dictionary<Screens, string>
		{
			{ Screens.HomeScreen,       "HomeScreen" },
			{ Screens.ConnectionScreen, "ConnectionScreen" },
			{ Screens.GameScreen,       "GameScreen" },
			{ Screens.ErrorScreen,      "ErrorScreen" }
		};
	}

	public void GoToHomeScreen()
	{
		SwitchScreen(Screens.HomeScreen);
	}

	public void GoToConnectionScreen()
	{
		SwitchScreen(Screens.ConnectionScreen);
	}

	public void GoToErrorScreen()
	{
		SwitchScreen(Screens.ErrorScreen);
	}

	public void SwitchScreen(Screens screen)
	{
		if(screensDictionary.ContainsKey(screen))
		{
			SceneManager.LoadScene(screensDictionary[screen]);
		}
	}
}
