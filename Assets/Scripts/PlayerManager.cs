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
		ServerManager.instance.CmdResetAllBombsAndDefusers();
	}

	[ClientRpc]
	public void RpcSetBombOrDefuser(float random, bool isDefuser)
	{
		if (isLocalPlayer)
		{
			LocalManager.instance.SetBombOrDefuser(random, isDefuser);
		}
	}
}
