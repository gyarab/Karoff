using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerID : NetworkBehaviour
{

    public string id;

    private void Start()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        id = GetComponent<NetworkIdentity>().netId.ToString();

        if (isServer) {
            this.transform.name = "host";
        }
        else
        {
            if (isClient) {
                this.transform.name = "client";
            }
        }


    }

    public string GetId()
    {
        if (!isLocalPlayer) {
            return "";
        }

        return id;
    }





}