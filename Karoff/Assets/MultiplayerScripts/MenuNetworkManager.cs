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

    public GameObject StartHostingButton;
    public GameObject ConnectToHostButton;
    public GameObject LocalGameButton;

    private void Start()
    {
       IP = GameObject.Find("IP");
       Port =  GameObject.Find("Port");
       StartHostingButton = GameObject.Find("StartHosting");
       ConnectToHostButton = GameObject.Find("ConnectToHost");
        LocalGameButton = GameObject.Find("Local");

    IP.transform.Find("Text").GetComponent<Text>().text = "localhost";
      Port.transform.Find("Text").GetComponent<Text>().text = "25565";
    }

  

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {

                SetupMenu();

            //Debug.Log(IP.transform.Find("Text").GetComponent<Text>().text);
            //Debug.Log(Port.transform.Find("Text").GetComponent<Text>().text);
            if (Input.GetKeyDown("escape")) {
                //base.StopHost();

                Application.Quit();
            }



        }
        if (SceneManager.GetActiveScene().name == "MultiplayerScene")
        {
            if (Input.GetKeyDown("escape"))
            {
                //pridat popup jestli chce odejit
                base.StopHost();
            }
        }
        if (SceneManager.GetActiveScene().name == "LocalScene")
        {
            if (Input.GetKeyDown("escape"))
            {
                //pridat popup jestli chce odejit
                SceneManager.LoadScene("MenuScene");
            }
        }

    }

    public void StartHosting() {
        FindObjectOfType<AudioManager>().Play("Build");
        base.StopHost();
        SetPort();
        base.StartHost();
   }

    private void SetPort()
    {
        string PortNumber = Port.transform.Find("Text").GetComponent<Text>().text;
        base.networkPort = int.Parse(PortNumber);

    }

    public void ConnnectToHost()
    {
        FindObjectOfType<AudioManager>().Play("Build");
        SetIP();
        SetPort();
        base.StartClient();
    }

    protected void SetIP() {
        string IPAdress = IP.transform.Find("Text").GetComponent<Text>().text;
        base.networkAddress = IPAdress;
    }

    public void PlayLocalOnOnePc() {
        FindObjectOfType<AudioManager>().Play("Build");
        SceneManager.LoadScene("LocalScene");
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0) {
            SetupMenu();
        }
    }

    public void SetupMenu() {
        IP = GameObject.Find("IP");
        Port = GameObject.Find("Port");
        StartHostingButton = GameObject.Find("StartHosting");
        ConnectToHostButton = GameObject.Find("ConnectToHost");
        LocalGameButton = GameObject.Find("Local");

        StartHostingButton.GetComponent<Button>().onClick.RemoveAllListeners();
        StartHostingButton.GetComponent<Button>().onClick.AddListener(StartHosting);
        //Debug.Log(StartHostingButton.GetComponent<Button>().onClick);
        ConnectToHostButton.GetComponent<Button>().onClick.RemoveAllListeners();
        ConnectToHostButton.GetComponent<Button>().onClick.AddListener(ConnnectToHost);

        LocalGameButton.GetComponent<Button>().onClick.RemoveAllListeners();
        LocalGameButton.GetComponent<Button>().onClick.AddListener(PlayLocalOnOnePc);
    }


}
