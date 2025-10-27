
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameStateManager gameStateManager;

    [SerializeField]
    GameObject ui1;
    [SerializeField]
    GameObject ui2;
    void Start()
    {
        gameStateManager.deathState.ui1 = ui1;
        gameStateManager.deathState.ui2 = ui2;

        gameStateManager.ChangeGameState(GameStatesEnum.GamePlayState);
    }

    private void Update()
    {
        gameStateManager.UpdateState();
    }

    private void FixedUpdate()
    {
        gameStateManager.FixedUpdateState();
    }

    public void StartDeath()
    {
        gameStateManager.ChangeGameState(GameStatesEnum.DeathState);
    }
}