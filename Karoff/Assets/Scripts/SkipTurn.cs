using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SkipTurn : MonoBehaviour
{

    private string player;
   
    void Start()
    {
        StartCoroutine(LateStart());
    }


    private void Update()
    {
        //detects enter key click
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //calls skip turn for local game
            if(SceneManager.GetActiveScene().name == "LocalScene") {

                LocalSkipTurn();

            }
            else if (SceneManager.GetActiveScene().name == "MultiplayerScene") {
                //calls skip turn for multiplayer networking game
                MultiplayerSkipTurn();
            }
        }
    }

    //waits and then gets information if player is host or client
    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);

        if (SceneManager.GetActiveScene().name == "MultiplayerScene")
        {

            var objects = GameObject.FindObjectsOfType<PlayerID>();

            foreach (var o in objects)
            {

                Debug.Log(o.ToString());
                if (o.ToString().Contains("host"))
                {
                    player = "host";
                }
                else if (o.ToString().Contains("client"))
                {
                    player = "client";
                }
            }
        }
    }

    //skips turn of player who called (calls functions for it)
    public void MultiplayerSkipTurn() {

        if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
        {
            FindObjectOfType<PlayerCommands>().Skip();
            FindObjectOfType<PlayerCommands>().ChangeTurn();


        }
        else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
        {
           
            FindObjectOfType<PlayerCommands>().Skip();
            FindObjectOfType<PlayerCommands>().ChangeTurn();

        }


    
    }

    //skips turn for active player on local game
    public void LocalSkipTurn()
    {

        if (FindObjectOfType<TurnManager>().currentTurn == "Red") {
            if (FindObjectOfType<ResourceManager>().redResources[0] - 3 < 0)
            {
                FindObjectOfType<ResourceManager>().ChangeRedPoints(-FindObjectOfType<ResourceManager>().redResources[0]);
            }
            else
            {
                FindObjectOfType<ResourceManager>().ChangeRedPoints(-3);
            }

            //Debug.Log(FindObjectOfType<ResourceManager>().redResources[1]);
            //Debug.Log((Mathf.FloorToInt(FindObjectOfType<ResourceManager>().redResources[1] * 0.8f)));
            FindObjectOfType<ResourceManager>().redResources[1] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().redResources[1] * 0.6f));
            FindObjectOfType<ResourceManager>().redResources[2] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().redResources[2] * 0.6f));
            FindObjectOfType<ResourceManager>().redResources[3] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().redResources[3] * 0.6f));
            FindObjectOfType<ResourceManager>().redResources[4] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().redResources[4] * 0.6f));

        }
        if(FindObjectOfType<TurnManager>().currentTurn == "Blue") {
            if (FindObjectOfType<ResourceManager>().blueResources[0] - 3 < 0)
            {
                FindObjectOfType<ResourceManager>().ChangeBluePoints(-FindObjectOfType<ResourceManager>().blueResources[0]);
            }
            else
            {
                FindObjectOfType<ResourceManager>().ChangeBluePoints(-3);
            }

            FindObjectOfType<ResourceManager>().blueResources[1] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().blueResources[1] * 0.6f));
            FindObjectOfType<ResourceManager>().blueResources[2] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().blueResources[2] * 0.6f));
            FindObjectOfType<ResourceManager>().blueResources[3] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().blueResources[3] * 0.6f));
            FindObjectOfType<ResourceManager>().blueResources[4] = (Mathf.FloorToInt(FindObjectOfType<ResourceManager>().blueResources[4] * 0.6f));
        }

        FindObjectOfType<TurnManager>().ChangeTurn();
    }




}
