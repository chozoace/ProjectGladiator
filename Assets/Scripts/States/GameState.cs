
using UnityEngine;
using System.Collections;

public abstract class GameState : ScriptableObject
{
    protected string stateName;
    public virtual string StateName { get { return stateName; } }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
}