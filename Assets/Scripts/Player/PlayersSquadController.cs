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
        GameObject playerGO = Instantiate(playerPrefab, this.transform.position, Quaternion.identity);
        playerGO.transform.parent = this.transform;
        players.Add(playerGO);

        //for development/testing
        //later it will instantiate the companions
        //on the player position, based on the GameData script
        GameObject[] companions = GameObject.FindGameObjectsWithTag("Companion");        
        foreach (var player in companions)
        {
            players.Add(player);
            GameData.instance.companions.Add(player);
        }

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
}
