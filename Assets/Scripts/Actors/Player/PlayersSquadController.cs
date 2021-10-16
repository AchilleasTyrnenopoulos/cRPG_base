using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSquadController : MonoBehaviour
{
    public static PlayersSquadController instance;

    public GameObject selectedPlayer;

    public List<GameObject> players = new List<GameObject>();

    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {        
        //Instatiate player
        GameObject playerGO = Instantiate(playerPrefab, this.transform.position, Quaternion.identity);
        playerGO.transform.parent = this.transform;
        players.Add(playerGO);

        //Instatiate companions
        if (GameData.instance.companions.Count != 0)
        {
            foreach (var companion in GameData.instance.companions)
            {
                if (companion != null)
                {
                    GameObject companionGO = Instantiate(companion, this.transform.position, Quaternion.identity);
                    companionGO.transform.parent = this.transform;
                    players.Add(companionGO);
                }
            }
        }
        //set selected player
        foreach (var player in players)
        {
            if(player.GetComponent<PlayerController>().selected)
            {
                selectedPlayer = player;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSelectedPlayer()
    {
        int index = 0;
        
        //get the list index of the selected player
        for(int i=0; i < players.Count; i++)
        {
            if(players[i] == selectedPlayer)
            {
                index = i;
            }
        }

        GameObject nextSelected;
        //check if index + 1 is bigger than list length
        if (index + 1 < players.Count)
            nextSelected = players[index + 1];
        else
            nextSelected = players[0];
        //set new selected player
        selectedPlayer = nextSelected;
       
        //change camera focus
        CameraController.instance.target = nextSelected;
        CameraController.instance.FollowTarget();
    }
}
