using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour 
{
    public Value<float> CurrentHealth { get; set; }
    public Value<int> Level { get; set; }
    
    //ATTRIBUTES
    public Stat<int> Strength { get; set ; }
    public Stat<int> Perception { get ; set ; }
    public Stat<int> Endurance { get ; set ; }
    public Stat<int> Charisma { get ; set ; }
    public Stat<int> Intelligense { get; set; }
    public Stat<int> Agility { get; set; }


    //inventory
}
