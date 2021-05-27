using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerController>();

        print("playerInput started");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
