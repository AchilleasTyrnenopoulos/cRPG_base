using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats 
{
    public int level = 1;

    public int strength = 10;      //baseMeleeDmg, maxHealth, maxInventory
    public int perception = 10;    //accuracy, baseDefence, maxVisibleRange, baseAtk
    public int endurance = 10;     //maxHealth, maxInventory, energyRegenRate 
    public int charisma = 10;      //speech, linguistics 
    public int intelligense = 10;  //spells/tech attacks, medicine (natural intel), craftmanship (math intel),   
    public int agility = 10;       //moveSpeed, angularSpeed, attackSpeed, baseDefense
    public int luck = 5;           //critical

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
