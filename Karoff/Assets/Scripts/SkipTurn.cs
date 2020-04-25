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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(SceneManager.GetActiveScene().name == "LocalScene") {

                // Pridat popup skip souhlas jestli ano tak LocalSkipTurn();   + varovani ze ztrati 3 pointy a 40% kazde resource

                LocalSkipTurn();


            }
            else if (SceneManager.GetActiveScene().name == "MultiplayerScene") {

                MultiplayerSkipTurn();
            }
        }
    }

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

    public void MultiplayerSkipTurn() {
        Debug.Log(player);
        
        if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
        {
            // Pridat popup skip souhlas jestli ano tak veskery zbytek co tu je     + varovani ze ztrati 3 pointy a 40% kazde resource 
            FindObjectOfType<PlayerCommands>().Skip();
            FindObjectOfType<PlayerCommands>().ChangeTurn();


        }
        else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
        {
            // Pridat popup skip souhlas jestli ano tak  veskery zbytek co tu je    + varovani ze ztrati 3 pointy a 40% kazde resource
            FindObjectOfType<PlayerCommands>().Skip();
            FindObjectOfType<PlayerCommands>().ChangeTurn();

        }


    
    }


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
