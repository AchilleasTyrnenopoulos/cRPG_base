using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneData : MonoBehaviour
{
    //[SerializeField]
    //private bool isEnteredBefore = false;
    // Start is called before the first frame update
    void Start()
    {
        string thisScene = SceneManager.GetActiveScene().name;
        //check if entered this scene before
        if (!GameData.instance.enteredScenes.Contains(thisScene))
        {
            //if not add scene name to scene names list of entered scenes
            GameData.instance.enteredScenes.Add(thisScene);
        }
        else
            print($"Entered this scene, named {thisScene}, before.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
