using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuNetworkManager : NetworkManager
{
    public GameObject IP;
    public GameObject Port;

    private void Start()
    {
      IP.GetComponent<Text>().text = "localhost";
      Port.GetComponent<Text>().text = "25565";
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            Debug.Log(IP.GetComponent<Text>().text);
            Debug.Log(Port.GetComponent<Text>().text);
        }
    }

    public void StartHosting() {
        SetPort();
        base.StartHost();
   }

    private void SetPort()
    {
        string PortNumber = Port.GetComponent<Text>().text;
        base.networkPort = int.Parse(PortNumber);
    }

    public void ConnnectToHost()
    {
        SetIP();
        SetPort();
        base.StartClient();
    }

    protected void SetIP() {
        string IPAdress = IP.GetComponent<Text>().text;
        base.networkAddress = IPAdress;
    }

    public void PlayLocalOnOnePc() {
        SceneManager.LoadScene("LocalScene");
    }


}
