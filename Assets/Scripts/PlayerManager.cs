﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {

	private ServerManager serverManager;
	private LocalManager  localManager;

	public override void OnStartLocalPlayer()
	{
		localManager = LocalManager.instance;
		localManager.SetLocalPlayer(this);
	}

	public override void OnStartServer()
	{
		serverManager = ServerManager.instance;
		serverManager.RegisterPlayer(gameObject);
	}
	

	private void OnDestroy()
	{
		if (serverManager != null)
		{
			serverManager.UnregisterPlayer(gameObject);
		}
	}

	[Command]
	public void CmdTryDefuse()
	{
		serverManager.ResetAllBombsAndDefusers();
	}

	[ClientRpc]
	public void RpcSetBombOrDefuser(float random, bool isDefuser)
	{
		if (isLocalPlayer)
		{
			localManager.SetBombOrDefuser(random, isDefuser);
		}
	}
}
