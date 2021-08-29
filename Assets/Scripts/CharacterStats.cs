using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterStats 
{
    
    Value<int> Level { get; set; }
    
    int Strength { get; set; }      //baseMeleeDmg, maxHealth, maxInventory
    int Perception { get; set; }    //accuracy, baseDefence, maxVisibleRange, baseAtk
    int Endurance { get; set; }     //maxHealth, maxInventory, energyRegenRate 
    int Charisma { get; set; }      //speech, linguistics 
    int Intelligense { get; set; }  //spells/tech attacks, medicine (natural intel), craftmanship (math intel),   
    int Agility { get; set; }       //moveSpeed, angularSpeed, attackSpeed, baseDefense
                                           //public int Luck = 5;           //critical

    //STR
    //baseMeleeDamage = strength
    //baseAtk = strength + intelligense + 3 * perception
    //maxHealth = 5 * strength + 5 * endurance

    //PER
    //accuracy = perception * 5
    //baseDefense = 3 * agility + 2 * perception

    //END
    //maxInventory = 2.5 * Endurance (ex. 25kg)
    //resistance
    //energyRegenerate

    //CHR
    //dialogue options
    //speech
    //linguistics(streetTongue, scholar)
    //attractiveness

    //INT
    //

    //AGL
    //moveSpeed = agility / 10
    //angular speed = agility * 36
    //attackSpeed = agility / 10

    //LUCK
    //
}
