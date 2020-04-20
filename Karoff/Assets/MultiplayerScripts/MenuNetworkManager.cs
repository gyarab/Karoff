using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuNetworkManager : NetworkManager
{
    public GameObject IP;
    public GameObject Port;

    private void Start()
    {
      IP.GetComponent<TMP_Text>().text = "localhost";
      Port.GetComponent<TMP_Text>().text = "25565";
    }

    private void Update()
    {
        //Debug.Log(IP.GetComponent<TMP_Text>().text);
    }

    public void StartHosting() {
        SetPort();
        base.StartHost();
   }

    private void SetPort()
    {
        string PortNumber = Port.GetComponent<TMP_Text>().text;
        base.networkPort = int.Parse(PortNumber);
    }

    public void ConnnectToHost()
    {
        SetIP();
        SetPort();
        base.StartClient();
    }

    protected void SetIP() {
        string IPAdress = IP.GetComponent<TMP_Text>().text;
        base.networkAddress = IPAdress;
    }

    public void PlayLocalOnOnePc() {
        SceneManager.LoadScene("SampleScene");
    }


}
