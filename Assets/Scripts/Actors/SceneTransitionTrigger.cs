using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    //[SerializeField]
    //private string id;
    [SerializeField]
    private string scene;
    [SerializeField]
    private Vector3 nextSceneStartPos;
    [SerializeField]
    private GameObject selectedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //EventManager.instance.SceneTransition += SceneTransition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneTransition()
    {
        //pass current scene and player position data to game data
        GameData.instance.curentScene = this.scene;
        GameData.instance.playerPosition = this.nextSceneStartPos;        
        
        //load scene
        SceneManager.LoadScene(this.scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if this transition is currently the selected target
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Companion"))
        {
            if(PlayersSquadController.instance.selectedPlayer.GetComponent<PlayerController>().target == this.gameObject)
            {
                //EventManager.instance.OnSceneTransitionEnter();
                SceneTransition();
            }
        }            
    }

}
