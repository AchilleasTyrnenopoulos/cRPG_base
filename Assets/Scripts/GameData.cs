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
    public List<string> enteredScenes = new List<string>();
    public bool cameraLockedOnTarget = false;
    public List<GameObject> companions = new List<GameObject>();

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
