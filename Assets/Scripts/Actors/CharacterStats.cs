using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Attributes
    [Header("ATTRIBURES")]
    public Stat strength;
    public Stat agility;
    public Stat intelligense;
    public Stat endurance;
    public Stat focus;
    public Stat charisma;

    #endregion

    #region Stats
    [Header("STATS")]
    //strength stats
    public Stat meleeAtk;
    public Stat meleeDmg;
    public Stat inventory;
    public int maxHealth;
    public int intimidation;

    //agility stats
    public Stat moveSpeed;
    public Stat atkSpeed;
    public Stat reflexes;
    public Stat sneak;

    //intelligense stats

    //endurance stats
    public Stat dmgReduction;
    public Stat resistance;
    public Stat healthRegen;

    //focus stats
    public Stat rangedAtk;
    public Stat sightRange;
    public Stat criticalChance;
    public Stat sense;

    //charisma stats
    public Stat speech;


    public int CurrentHealth { get; private set; }
    #endregion

    private void Start()
    {

    }
}
