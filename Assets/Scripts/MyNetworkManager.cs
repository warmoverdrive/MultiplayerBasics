using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect(conn);

		Debug.Log("I Connected to a Server!");
	}

	public override void OnServerAddPlayer(NetworkConnection conn)
	{
		base.OnServerAddPlayer(conn);

		Debug.Log($"Player has been added. There is now {numPlayers} player(s) connected.");
	}
}
