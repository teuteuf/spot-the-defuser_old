using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalManager : MonoBehaviour {
	public static LocalManager instance;

	private PlayerManager localPlayer;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public void SetLocalPlayer(PlayerManager player)
	{
		Debug.Assert(localPlayer == null, "Local player already set!");
		localPlayer = player;
	}

	public void TryDefuseLocalPlayer()
	{
		localPlayer.CmdTryDefuse();
	}
}
