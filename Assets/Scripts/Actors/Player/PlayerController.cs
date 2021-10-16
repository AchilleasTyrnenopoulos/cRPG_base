using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    //public static PlayerController instance;

    public string playerId;

    public NavMeshAgent agent;

    public GameObject target;

    public bool selected;

    [SerializeField]
    internal PlayerHealth playerHealthScript;
    [SerializeField]
    internal CharacterStats playerStats;


    [SerializeField]
    LayerMask leftClickMask;
    [SerializeField]
    LayerMask rightClickMask;

    public event Action<string> LeftClick;

    public event Action<string> RightClick;

    #endregion



    private void Awake()
    {
        //instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //later check what the selected player is in GameData
        if (this.CompareTag(Tags.player))
        {
            CameraController.instance.target = this.gameObject;
        }

        playerId = this.gameObject.name;
        RightClick += RightMouseClick;
        LeftClick += LeftMouseClick;

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
                GameObject hitColliderGO = hit.collider.gameObject.transform.parent.gameObject;

                string tag = hitCollider.tag;
                switch (tag)
                {
                    case (Tags.player):
                        print("player selected.");
                        DeselectAllPlayers();
                        PlayersSquadController.instance.selectedPlayer = hitColliderGO;
                        hitColliderGO.GetComponent<PlayerController>().selected = true;
                        CameraController.instance.target = hitColliderGO;
                        CameraController.instance.FollowTarget();
                        break;
                    case ("Companion"):
                        print("companion selected.");
                        DeselectAllPlayers();
                        PlayersSquadController.instance.selectedPlayer = hitColliderGO;
                        hitColliderGO.GetComponent<PlayerController>().selected = true;
                        CameraController.instance.target = hitColliderGO;
                        CameraController.instance.FollowTarget();
                        break;
                }
            }
        }
        //else
        //    Debug.LogError("something unexpexted is going on. . .");
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
                    case Tags.ground:
                        target = null;
                        clickPos = hit.point;

                        print(clickPos);

                        Move(clickPos, 0f);
                        break;
                    case Tags.companion:
                        target = hitCollider.transform.parent.gameObject;
                        print(target.name);
                        Move(target);
                        break;
                    case Tags.npc:
                        target = hitCollider.gameObject;

                        print(hitColliderGO.name);

                        Move(target, 2f);
                        break;
                    case Tags.enemy:
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
                    case Tags.sceneTransition:
                        target = hitColliderGO;
                        Move(target);
                        break;
                    case Tags.ignoreRaycast:
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
        List<GameObject> players = PlayersSquadController.instance.players;
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
        RightClick -= RightMouseClick;
        LeftClick -= LeftMouseClick;
    }

    public void OnLeftClick(string id)
    {
        LeftClick?.Invoke(id);
    }

    public void OnRightClick(string id)
    {
        RightClick?.Invoke(id);
    }
}
