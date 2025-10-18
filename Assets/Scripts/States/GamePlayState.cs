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
        for (int i = 0; i < world.Updateables.Count; i++)
        {
            IUpdateable obj = world.Updateables[i];
            obj.FixedUpdateSelf();
        }
    }

    public override void UpdateState()
    {
        for (int i = 0; i < world.Updateables.Count; i++)
        {
            IUpdateable obj = world.Updateables[i];
            obj.UpdateSelf();
        }
    }
}
