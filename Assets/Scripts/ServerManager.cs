using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager : NetworkBehaviour {

	public static ServerManager instance;

	public List<PlayerManager> players;

	private void Awake()
	{
		if(instance == null) {
			instance = this;
		}
	}

	[Command]
	public void CmdRegisterPlayer(GameObject playerGameObject)
	{
		players.Add(playerGameObject.GetComponent<PlayerManager>());
		Debug.LogError("Nb players registred: " + players.Count);
	}

	[Command]
	public void CmdLogAllPlayers()
	{
		for(int i = 0; i < players.Count; i++)
		{
			players[i].RpcLogPlayer(i);
		}
	}
}
