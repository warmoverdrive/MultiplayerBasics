using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MyNetworkPlayer : NetworkBehaviour
{
	[SerializeField] private TMP_Text displayNameText = null;
	[SerializeField] private Renderer displayColorRenderer = null;

	[SyncVar(hook = nameof(HandleDisplayNameUpdated))]
	[SerializeField]
	private string displayName = "Missing Name";

	[SyncVar(hook = nameof(HandleDisplayColorUpdated))]
	[SerializeField]
	private Color displayColor = Color.white;

	[Server]
	public void SetDisplayName(string newDisplayName) { displayName = newDisplayName; }
	[Server]
	public string GetDisplayName() { return displayName; }
	[Server]
	public void SetDisplayColor(Color newColor) { displayColor = newColor; }

	private void HandleDisplayColorUpdated(Color oldColor, Color newColor)
	{
		displayColorRenderer.material.SetColor("_BaseColor", newColor);
	}

	private void HandleDisplayNameUpdated(string oldName, string newName)
	{
		displayNameText.text = newName;
	}
}
