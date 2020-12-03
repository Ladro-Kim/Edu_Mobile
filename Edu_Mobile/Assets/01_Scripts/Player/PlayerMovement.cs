using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    Rigidbody playerRigid;
    GameObject go_joystick;
    JoystickInput input;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        go_joystick = GameObject.Find("Background");
        input = go_joystick.GetComponent<JoystickInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;

        if (input.isTouch)
        {
            playerRigid.MovePosition(transform.position + input.dir * moveSpeed * Time.deltaTime);
        }
    }
}
