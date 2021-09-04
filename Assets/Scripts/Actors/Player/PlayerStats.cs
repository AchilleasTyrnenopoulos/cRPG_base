using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Awake()
    {
        //check if is main player
        if (this.gameObject.tag == "Player")
        {
            //get attributes from game data
            strength.SetBaseValue(GameData.instance.strength);
            agility.SetBaseValue(GameData.instance.agility);
            intelligense.SetBaseValue(GameData.instance.intelligense);
            endurance.SetBaseValue(GameData.instance.endurance);
            focus.SetBaseValue(GameData.instance.focus);
            charisma.SetBaseValue(GameData.instance.charisma);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //calculate stats
        //strength stats
        maxHealth = strength.GetValue() * 20;
        meleeAtk.SetBaseValue(strength.GetValue());
        meleeDmg.SetBaseValue(strength.GetValue() * 2);
        inventory.SetBaseValue(strength.GetValue() * 10);
        intimidation = strength.GetValue();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
