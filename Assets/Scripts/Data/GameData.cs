using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    [Header("Scene Data")]    
    public string curentScene;    
    public Vector3 playerPosition;    

    [Header("Game Data")]
    public int strength;
    public int agility;
    public int intelligense;
    public int focus;
    public int endurance;
    public int charisma;

    public List<string> enteredScenes = new List<string>();
    public bool cameraLockedOnTarget = false;
    public List<GameObject> companions = new List<GameObject>();

    [Header("Date & Time")]
    public int days = -1;
    [Range(0, 23)]
    public int hour = 0;
    [Range(0, 59)]
    public int minute = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        print("GameData script started.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
