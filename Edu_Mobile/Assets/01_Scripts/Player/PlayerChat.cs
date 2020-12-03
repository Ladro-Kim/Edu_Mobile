using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerChat : MonoBehaviour
{

    public Text text_chat;
    public InputField if_input;
    int playerLevel = 1;
    PhotonView photonView;

    private void Start()
    {
        text_chat = GameObject.Find("Text_Chat").GetComponent<Text>();
        if_input = GameObject.Find("IF_InputField").GetComponent<InputField>();
        photonView = GetComponent<PhotonView>();
    }


    [PunRPC]
    public void OnClickSendButton()
    {
        text_chat.text += $"\n {if_input.text} {playerLevel}";
        if_input.text = "";
    }

    [PunRPC]
    public void ApplyUpdatedLevel(int playerLevel)
    {
        this.playerLevel = playerLevel;
    }

    [PunRPC]
    public void LevelUp()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ++playerLevel;
            photonView.RPC("ApplyUpdatedLevel", RpcTarget.Others, playerLevel);
        }

 
    }


}
