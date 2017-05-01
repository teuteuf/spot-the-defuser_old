using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {

	void Start()
	{
		if (isServer)
		{
			ServerManager.instance.CmdRegisterPlayer(gameObject);
		}

		if (isLocalPlayer)
		{
			LocalManager.instance.SetLocalPlayer(this);
		}
	}

	[Command]
	public void CmdTryDefuse()
	{
		ServerManager.instance.CmdLogAllPlayers();
	}

	[ClientRpc]
	public void RpcLogPlayer(int index)
	{
		if (isLocalPlayer)
			Debug.LogError("Player: " + index);
	}
}
