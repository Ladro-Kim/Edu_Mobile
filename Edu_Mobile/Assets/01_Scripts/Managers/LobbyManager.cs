using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";

    public Text statusText;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        statusText.text = "Connecting...";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        statusText.text = "Connected. Press button";

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        statusText.text = "Disconnected. Wait...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        statusText.text = "Failed to join a room";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });

    }

    public override void OnJoinedRoom()
    {
        statusText.text = "방 참가 성공";
        PhotonNetwork.LoadLevel("InGameScene");
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            statusText.text = "접속중...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            statusText.text = "There is no master...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }



}
