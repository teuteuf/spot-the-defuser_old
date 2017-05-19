using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StdNetworkDiscovery : NetworkDiscovery
{
	public float timerBeforeBroadcast = 5.0f;

	private bool broadcastReceived = false;

	void Start()
	{
		Initialize();
		StartAsClient();
		StartCoroutine("CheckShouldStartBroadcasting");
	}

	IEnumerator CheckShouldStartBroadcasting()
	{
		yield return new WaitForSeconds(timerBeforeBroadcast);

		if (!broadcastReceived)
		{
			StopBroadcast();
			Initialize();
			StartAsServer();
			NetworkManager.singleton.StartHost();
		}
	}

	public override void OnReceivedBroadcast(string fromAddress, string data)
	{
		broadcastReceived = true;
		NetworkManager.singleton.networkAddress = fromAddress;
		NetworkManager.singleton.StartClient();
		StopBroadcast();
	}

	private void OnDestroy()
	{
		StopBroadcast();
	}
}
