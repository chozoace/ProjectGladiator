using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private GameObject _playerRef;
    private Fighter _enemyRef;
    private Rigidbody2D _rigidBody2D;

    private float _attackDistance = .8f;

    public EnemyAttackState(Fighter enemyRef)
    {
        _enemyRef = enemyRef;
        _playerRef = GameObject.FindWithTag("Player");
        _rigidBody2D = enemyRef.GetComponent<Rigidbody2D>();
    }

    public override void Enter() { }
    public override void Exit() { }
    public override void UpdateState()
    {
        
    }
    public override void FixedUpdateState()
    {
        if (Vector2.Distance(_playerRef.transform.position, _enemyRef.transform.position) > _attackDistance)
        {
            Vector2 travelDir = (_playerRef.transform.position - _enemyRef.transform.position).normalized;
            _rigidBody2D.linearVelocity = travelDir * _enemyRef._fighterSpeed;
        }
        else
        {
            //attack
            _rigidBody2D.linearVelocity = Vector2.zero;
        }
    }
}