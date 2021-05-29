using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    //public static PlayerController instance;

    public string playerId;

    public GameObject target;
    
    public bool selected;

    [SerializeField]
    internal PlayerHealth playerHealthScript;

    private NavMeshAgent agent;
    [SerializeField]
    LayerMask leftClickMask;
    [SerializeField]
    LayerMask rightClickMask;

    #endregion



    private void Awake()
    {
        //instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraController.instance.target = this.gameObject;

        playerId = this.gameObject.name;
        EventManager.instance.RightClick += RightMouseClick;
        EventManager.instance.LeftClick += LeftMouseClick;

        agent = GetComponent<NavMeshAgent>();

        //load player position
        //if(GameData.instance.playerPosition != null)
        //    this.transform.position = GameData.instance.playerPosition;

        print("playerScript started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Methods
    public void Move(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
    public void Move(GameObject target)
    {
        agent.SetDestination(target.transform.position);
    }
    public void Move(Vector3 pos, float agentStopDistance)
    {
        agent.stoppingDistance = agentStopDistance;
        agent.SetDestination(pos);
    }
    public void Move(GameObject target, float agentStopDistance)
    {
        agent.stoppingDistance = agentStopDistance;
        agent.SetDestination(target.transform.position);
    }

    public void LeftMouseClick(string id)
    {
        if (id == playerId)
        {
            //Vector3 clickPos;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, leftClickMask))
            {
                Collider hitCollider = hit.collider;
                GameObject hitColliderGO = hit.collider.gameObject;

                string tag = hitCollider.tag;
                switch (tag)
                {
                    case ("Player"):
                        DeselectAllPlayers();
                        PlayersSquadController.instance.selectedPlayer = hitColliderGO;
                        hitColliderGO.GetComponent<PlayerController>().selected = true;
                        CameraController.instance.target = hitColliderGO;
                        break;
                    case ("Companion"):
                        DeselectAllPlayers();
                        PlayersSquadController.instance.selectedPlayer = hitColliderGO;
                        hitColliderGO.GetComponent<PlayerController>().selected = true;
                        CameraController.instance.target = hitColliderGO;
                        break;
                }
            }
        }
    }

    public void RightMouseClick(string id)
    {
        if (id == playerId)
        {
            Vector3 clickPos;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, rightClickMask))
            {
                Collider hitCollider = hit.collider;
                GameObject hitColliderGO = hit.collider.gameObject;

                string tag = hitCollider.tag;
                switch (tag)
                {
                    case "Ground":
                        target = null;
                        clickPos = hit.point;

                        print(clickPos);

                        Move(clickPos, 0f);
                        break;
                    case "NPC":
                        target = hitCollider.gameObject;

                        print(hitColliderGO.name);

                        Move(target, 2f);
                        break;
                    case "Enemy":
                        //clickPos = hit.point;
                        target = hitCollider.gameObject;

                        print(hitColliderGO.name);
                        //calculate stoppoing distance depending on the active weapon

                        if (Vector3.Distance(agent.transform.position, hitColliderGO.transform.position) > 2/*activeWeapon.range*/)
                        {
                            //agent.stoppingDistance = activeWeapon.range
                            Move(target, 2f);
                            if (!agent.hasPath)
                            {
                                //attack
                                print("attack");
                            }

                        }
                        else
                        {
                            //attack                    
                            print("attack");
                        }
                        break;
                    case "SceneTransition":
                        target = hitColliderGO;
                        Move(target);
                        break;
                    case "Ignore Raycast":
                        break;
                    default:
                        Debug.LogError("Tag for specific layer has not been assigned.");
                        break;
                }
            }
        }
    }
    #endregion

    public void DeselectAllPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerController>().selected = false;
        }
        PlayersSquadController.instance.selectedPlayer = null;
        print("Deselected all players");
    }

    private void OnDisable()
    {
        //print("Disabled");
        EventManager.instance.RightClick -= RightMouseClick;
        EventManager.instance.LeftClick -= LeftMouseClick;
    }

}
