using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerID : NetworkBehaviour
{


    [SyncVar] public string id;

    private void Start()
    {
        GameObject Manager = GameObject.FindGameObjectWithTag("Manager");
        if (!isLocalPlayer)
        {
            return;
        }

        id = GetComponent<NetworkIdentity>().netId.ToString();


        if (SceneManager.GetActiveScene().name == "OnlineScene")
        {


            if (Manager.GetComponent<TurnManager>().GetHost() == "" || Manager.GetComponent<TurnManager>().GetHost() == null)
            {
                Debug.Log(this.GetComponent<PlayerID>().GetId() + " ID");
                Manager.GetComponent<TurnManager>().SetHost(this.GetComponent<PlayerID>().GetId());

            }
            Debug.Log(Manager.GetComponent<TurnManager>().GetHost());
        }
    }

   

    public string GetId()
    {
        return id;
    }





}