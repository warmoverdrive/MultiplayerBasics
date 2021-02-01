using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
	public override void OnServerAddPlayer(NetworkConnection conn)
	{
		base.OnServerAddPlayer(conn);

		MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

		player.SetDisplayName($"Player {numPlayers}");
		player.SetDisplayColor(new Color(Random.value, Random.value, Random.value));

		Debug.Log($"{player.GetDisplayName()} has connected!");
	}
}
