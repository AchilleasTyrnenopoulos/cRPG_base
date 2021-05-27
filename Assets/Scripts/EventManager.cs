using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    //public event Action SceneTransition;

    public event Action<string> LeftClick;

    public event Action<string> RightClick;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnSceneTransitionEnter()
    //{
    //    SceneTransition?.Invoke();
    //}

    public void OnLeftClick(string id)
    {
        LeftClick?.Invoke(id);
    }

    public void OnRightClick(string id)
    {
        RightClick?.Invoke(id);
    }
}
