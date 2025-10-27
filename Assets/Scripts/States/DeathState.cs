
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "DeathState", menuName = "ScriptableObjects/GameStates/DeathState", order = 1)]
public class DeathState : GameState
{
    public GameObject ui1;
    public GameObject ui2;
    [SerializeReference]
    GameWorld world;
    public override void Enter()
    {
        //for now, create menus immediately
        ui1.SetActive(true);
        ui2.SetActive(true);
        world.Updateables.Clear();
    }

    public override void Exit()
    {

    }
    
    //have event listener to create menus

    public override void FixedUpdateState()
    {
        
    }

    public override void UpdateState()
    {
       if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}