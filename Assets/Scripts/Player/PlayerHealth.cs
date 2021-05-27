using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerController playerScript;

    [SerializeField]
    int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerController>();

        currentHealth = maxHealth;

        print("PlayerHealthScript started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
