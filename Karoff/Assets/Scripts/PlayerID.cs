using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerId : NetworkBehaviour
{


    public string id;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        id = GetComponent<NetworkIdentity>().netId.ToString();



    }

    public string GetId()
    {
        return id;
    }





}