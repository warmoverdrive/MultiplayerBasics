using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
	[SyncVar]
	[SerializeField]
	private string displayName = "Missing Name";
	[SyncVar]
	[SerializeField]
	private Color displayColor = Color.white;

	[Server]
	public void SetDisplayName(string newDisplayName) { displayName = newDisplayName; }
	[Server]
	public string GetDisplayName() { return displayName; }
	[Server]
	public void SetDisplayColor(Color newColor) { displayColor = newColor; }
}
