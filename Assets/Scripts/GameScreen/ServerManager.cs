using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager : NetworkBehaviour {

	public static ServerManager instance;

	public List<PlayerManager> players;

	private void Awake()
	{
		Debug.Assert(instance == null, "Tried to init ServerManager instance twice!");
		instance = this;
	}

	public void RegisterPlayer(GameObject playerGameObject)
	{
		players.Add(playerGameObject.GetComponent<PlayerManager>());
		Debug.Log("Player registered! Nb players registered: " + players.Count);
	}

	public void OnPlayerDestroy(GameObject playerGameObject)
	{
		players.Remove(playerGameObject.GetComponent<PlayerManager>());
		Debug.Log("Player unregistered! Nb players registered: " + players.Count);

		foreach(PlayerManager player in players)
		{
			player.RpcOnErrorOccured();
		}
	}

	public void ResetAllBombsAndDefusers()
	{
		float randomValue = Random.value;
		int defuserIndex = Random.Range(0, players.Count);

		for (int i = 0; i < players.Count; i++)
		{
			players[i].RpcSetBombOrDefuser(randomValue, i == defuserIndex);
		}
	}
}
