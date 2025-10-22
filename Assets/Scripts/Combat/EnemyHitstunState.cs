
using UnityEngine;

public class EnemyHitstunState : EnemyState
{
    private GameObject _playerRef;
    private Fighter _enemyRef;
    private Rigidbody2D _rigidBody2D;

    private float _attackDistance = .8f;

    public EnemyHitstunState(Fighter enemyRef)
    {
        //maybe initial launch?
        _enemyRef = enemyRef;
    }

    public override void Enter() { }
    public override void Exit() { }
    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {
        
    }
}