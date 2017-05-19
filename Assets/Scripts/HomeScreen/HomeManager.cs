using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HomeManager : MonoBehaviour {
	void Start () {
		// Destroy existing Network Manager
		NetworkManager networkManager = FindObjectOfType<NetworkManager>();
		
		if(networkManager != null)
		{
			Destroy(networkManager.gameObject);
		}
	}
}
