using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Trying to connect...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        PhotonNetwork.JoinOrCreateRoom(
            "Room1",
            new RoomOptions { MaxPlayers = 5 },
            TypedLobby.Default
        );
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room SUCCESS");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected: " + cause);
    }
}