using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	const string VERSION = "v0.1";
	const string ROOM = "TestEivind";

	public string playerPrefabName = "Player";
	public Transform spawnPoint;
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings(VERSION);


	}
	
	// Update is called once per frame
	void OnJoinedLobby () {
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 2 };
		PhotonNetwork.JoinOrCreateRoom(ROOM, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.position, spawnPoint.rotation, 0);
	}
}
