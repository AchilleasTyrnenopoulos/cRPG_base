using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquadSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject playerSquadPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 instancePosition;
        if(GameData.instance.playerPosition != Vector3.zero)
        {
            instancePosition = GameData.instance.playerPosition;            
        }
        else
        {
            instancePosition = this.transform.position;            
        }

        Instantiate(playerSquadPrefab, instancePosition, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
