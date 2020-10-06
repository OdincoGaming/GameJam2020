﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    [SerializeField]
    private ActionType actionType;

    [SerializeField]
    private string _name; 
}

public enum ActionType {Attack, Item, Switch, Flee}