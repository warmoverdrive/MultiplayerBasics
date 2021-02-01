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

	#region Server

	[Server]
	public void SetDisplayName(string newDisplayName) { displayName = newDisplayName; }

	[Server]
	public string GetDisplayName() { return displayName; }

	[Server]
	public void SetDisplayColor(Color newColor) { displayColor = newColor; }

	[Command]
	private void CmdSetDisplayName(string newDisplayName)
	{
		if (newDisplayName.Length < 2 || newDisplayName.Length > 10)
			return;

		RpcLogNewName(newDisplayName);

		SetDisplayName(newDisplayName);
	}

	#endregion
	#region Client

	private void HandleDisplayColorUpdated(Color oldColor, Color newColor)
	{
		displayColorRenderer.material.SetColor("_BaseColor", newColor);
	}

	private void HandleDisplayNameUpdated(string oldName, string newName)
	{
		displayNameText.text = newName;
	}

	[ContextMenu("Set My Name")]
	private void SetMyName()
	{
		CmdSetDisplayName("x");
	}

	[ClientRpc]
	public void RpcLogNewName(string newDisplayName)
	{
		Debug.Log($"Name changed to {newDisplayName}.");
	}

	#endregion

}
