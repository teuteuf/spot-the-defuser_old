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
		Debug.Log("Nb players registred: " + players.Count);
	}

	[Command]
	public void CmdResetAllBombsAndDefusers()
	{
		float randomValue = Random.value;
		int defuserIndex = Random.Range(0, players.Count);

		for (int i = 0; i < players.Count; i++)
		{
			players[i].RpcSetBombOrDefuser(randomValue, i == defuserIndex);
		}
	}
}
