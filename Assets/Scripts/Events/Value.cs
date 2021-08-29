using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value<T>
{

    public T Val { get { return m_CurrentValue; } }
    public T PrevVal { get { return m_PreviousValue; } }
    [SerializeField]
    private T m_CurrentValue;
    [SerializeField]
    private T m_PreviousValue;

    private Action<T> m_Set;

    #region Constructors
    public Value()
    {
        m_CurrentValue = default(T);
        m_PreviousValue = default(T);
    }

    public Value(T initialValue)
    {
        m_CurrentValue = initialValue;
        m_PreviousValue = m_CurrentValue;
    }
    #endregion

    public void AddChangeListener(Action<T> callback)
    {
        m_Set += callback;
    }

    public void RemoveChangeListener(Action<T> callback)
    {
        m_Set -= callback;
    }

    public T Get()
    {
        return m_CurrentValue;
    }

    /// <summary>Returns the previous value.</summary>
    public T GetPreviousValue()
    {
        return m_PreviousValue;
    }

    public void Set(T value)
    {
        m_PreviousValue = m_CurrentValue;
        m_CurrentValue = value;

        if (m_Set != null && ((m_PreviousValue == null && m_CurrentValue != null)
                || (m_PreviousValue != null && !m_PreviousValue.Equals(m_CurrentValue))))
            m_Set(m_CurrentValue);
    }

    public bool Is(T value)
    {
        return m_CurrentValue != null && m_CurrentValue.Equals(value);
    }
}
