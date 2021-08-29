using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat<T>
{    

    public float BaseStatValue { get { return m_BaseStatValue; }  }
    private float m_BaseStatValue;

    public List<StatModifier> statModifiers;

    public Value<float> Value { get { return CalculateFinalValue(); } }

    public void AddModifier(StatModifier mod)
    {
        statModifiers.Add(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        return statModifiers.Remove(mod);
    }

    private Value<float> CalculateFinalValue()
    {
        float finalValue = m_BaseStatValue;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            finalValue += statModifiers[i].StatModValue; ;
        }
        // Rounding gets around dumb float calculation errors (like getting 12.0001f, instead of 12f)
        // 4 significant digits is usually precise enough, but feel free to change this to fit your needs
        return new Value<float>((float)Math.Round(finalValue, 4));
    }


}
