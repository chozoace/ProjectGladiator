using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameStateManager", menuName = "ScriptableObjects/GameStateManager", order = 2)]
public class GameStateManager : ScriptableObject
{
    private Dictionary<GameStatesEnum, GameState> gameStateMap;

    [SerializeField]
    private GamePlayState gamePlayState;

    [SerializeField]
    public DeathState deathState;

    private GameState currentGameState;

    private void OnEnable()
    {
        gameStateMap = new Dictionary<GameStatesEnum, GameState>
        {
            { GameStatesEnum.GamePlayState, gamePlayState },
            { GameStatesEnum.DeathState, deathState }
        };
    }

    public void ChangeGameState(GameStatesEnum newStateEnum)
    {
        GameState newState = gameStateMap[newStateEnum];

        if(currentGameState != null)
            currentGameState.Exit();
        currentGameState = newState;
        currentGameState.Enter();
    }

    public void UpdateState()
    {
        currentGameState.UpdateState();
    }

    public void FixedUpdateState()
    {
        currentGameState.FixedUpdateState();
    }
}
public enum GameStatesEnum
{
    GamePlayState,
    DeathState
}
