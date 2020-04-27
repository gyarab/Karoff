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
        // finds and selects objects
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
        //listens for escape key to leave
        if (SceneManager.GetActiveScene().name == "MenuScene")
        { 
            SetupMenu();
            if (Input.GetKeyDown("escape")) {
                //quit game
                Application.Quit();
            }
        }
        if (SceneManager.GetActiveScene().name == "MultiplayerScene")
        {
            //sets first music
            if (Input.GetKeyDown("escape"))
            {
                FindObjectOfType<AudioManager>().Stop("Main1");
                FindObjectOfType<AudioManager>().Stop("Main2");
                FindObjectOfType<AudioManager>().Stop("Main3");
                FindObjectOfType<AudioManager>().Play("Main1");
                //stops hosting/leaves game
                base.StopHost();
            }
        }
        if (SceneManager.GetActiveScene().name == "LocalScene")
        {
            if (Input.GetKeyDown("escape"))
            {
                //sets first music
                FindObjectOfType<AudioManager>().Stop("Main1");
                FindObjectOfType<AudioManager>().Stop("Main2");
                FindObjectOfType<AudioManager>().Stop("Main3");
                FindObjectOfType<AudioManager>().Play("Main1");
                //goes menu
                SceneManager.LoadScene("MenuScene");
            }
        }

    }

   
    //start hosting
    public void StartHosting() {
        FindObjectOfType<AudioManager>().Play("Build");
        base.StopHost();
        SetPort();
        base.StartHost();
   }

    //set port from input field
    private void SetPort()
    {
        string PortNumber = Port.transform.Find("Text").GetComponent<Text>().text;
        base.networkPort = int.Parse(PortNumber);

    }

    //connect to host on port and IP from iput fields
    public void ConnnectToHost()
    {
        FindObjectOfType<AudioManager>().Play("Build");
        SetIP();
        SetPort();
        base.StartClient();
    }

    //set IP from input field
    protected void SetIP() {
        string IPAdress = IP.transform.Find("Text").GetComponent<Text>().text;
        base.networkAddress = IPAdress;
    }

    //Starts local scene game
    public void PlayLocalOnOnePc() {
        FindObjectOfType<AudioManager>().Play("Build");
        SceneManager.LoadScene("LocalScene");
    }

    // has to set objects when loaded but not really well works so there are many other checks to guarantee
    private void OnLevelWasLoaded(int level)
    {
        if(level == 0) {
            SetupMenu();
        }
    }

    //finds sets objects as at start but with onClick listeners
    public void SetupMenu() {
        IP = GameObject.Find("IP");
        Port = GameObject.Find("Port");
        StartHostingButton = GameObject.Find("StartHosting");
        ConnectToHostButton = GameObject.Find("ConnectToHost");
        LocalGameButton = GameObject.Find("Local");

        StartHostingButton.GetComponent<Button>().onClick.RemoveAllListeners();
        StartHostingButton.GetComponent<Button>().onClick.AddListener(StartHosting);
       
        ConnectToHostButton.GetComponent<Button>().onClick.RemoveAllListeners();
        ConnectToHostButton.GetComponent<Button>().onClick.AddListener(ConnnectToHost);

        LocalGameButton.GetComponent<Button>().onClick.RemoveAllListeners();
        LocalGameButton.GetComponent<Button>().onClick.AddListener(PlayLocalOnOnePc);
    }

    //stops hosting not sure if used anywhere now but may be usefull in future
    public void StopHosting() {
        base.StopHost();
    }

}
