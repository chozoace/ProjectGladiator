using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayState", menuName = "ScriptableObjects/GameStates/GamePlayState", order = 1)]
public class GamePlayState : GameState
{
    [SerializeField]
    GameWorld world;
    private void OnEnable()
    {
        this.stateName = "GamePlayState";
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdateState()
    {
        foreach (IUpdateable obj in world.Updateables)
        {
            obj.FixedUpdateSelf();
        }
    }

    public override void UpdateState()
    {
        foreach (IUpdateable obj in world.Updateables)
        {
            obj.UpdateSelf();
        }
    }
}
