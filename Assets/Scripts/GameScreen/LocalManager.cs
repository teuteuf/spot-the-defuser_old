using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalManager : MonoBehaviour {
	public static LocalManager instance;

	public UIManager uiManager;

	public Image uiSprite;

	public List<Sprite> listDefusers;
	public List<Sprite> listBombs;

	private PlayerManager localPlayer;

	private void Awake()
	{
		Debug.Assert(instance == null, "Tried to init LocalManager instance twice!");
		instance = this;

		Debug.Assert(listDefusers.Count == listBombs.Count, "Not same count of bombs and defusers!");
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
	
	public void SetBombOrDefuser(float random, bool isDefuser)
	{
		int nbBombs = listBombs.Count;
		int randomIndex = Mathf.Min((int) Mathf.Floor(nbBombs * random), nbBombs - 1);
		uiSprite.sprite = isDefuser ? listDefusers[randomIndex] : listBombs[randomIndex];
	}
}
