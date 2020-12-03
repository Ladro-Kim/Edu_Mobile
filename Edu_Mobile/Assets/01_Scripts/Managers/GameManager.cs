using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    static GameManager INSTANCE;
    public static GameManager manager { get { Init(); return INSTANCE; } }

    public GameObject playerPrefab;
    public GameObject instantiatePos1, instantiatePos2;

    static int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        if (index == 0)
        PhotonNetwork.Instantiate("Player", instantiatePos1.transform.position, Quaternion.identity);
        index++;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void Init()
    {
        if (INSTANCE == null)
        {
            GameObject go_gameManager = GameObject.Find("@GameManager");
            if (go_gameManager == null)
            {
                go_gameManager = new GameObject { name = "@GameManager" };
                go_gameManager.AddComponent<GameManager>();
            }
            INSTANCE = go_gameManager.GetComponent<GameManager>();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
