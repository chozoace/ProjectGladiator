using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyHuntState : EnemyState
{
    private GameObject _playerRef;
    private Fighter _enemyRef;
    private Rigidbody2D _rigidBody2D;

    private float _attackDistance = .8f;

    private Animator _anim;

    public EnemyHuntState(Fighter enemyRef)
    {
        _enemyRef = enemyRef;
        _anim = _enemyRef.GetComponent<Animator>();
        _playerRef = GameObject.FindWithTag("Player");
        _rigidBody2D = enemyRef.GetComponent<Rigidbody2D>();
    }

    public override void Enter() { }
    public override void Exit()
    {
        _rigidBody2D.linearVelocity = Vector2.zero;
    }
    public override void UpdateState()
    {
        
    }
    public override void FixedUpdateState()
    {
        if (_enemyRef && !_enemyRef.IsAttacking)
        {
            if (Vector2.Distance(_playerRef.transform.position, _enemyRef.transform.position) > _attackDistance)
            {
                Vector2 travelDir = (_playerRef.transform.position - _enemyRef.transform.position).normalized;
                _rigidBody2D.linearVelocity = travelDir * _enemyRef._fighterSpeed;
                _anim.SetInteger("direction", GetDirection(travelDir));
            }
            else
            {
                //attack
                int attDir = GetAttackDirection(_enemyRef.transform.position, _playerRef.transform.position);
                _rigidBody2D.linearVelocity = Vector2.zero;
                _enemyRef.StartAttack(attDir);
            }
        }
    }
    
    private int GetDirection(Vector2 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            // Horizontal direction
            return input.x > 0 ? 3 : 1; // Right : Left
        }
        else
        {
            // Vertical direction
            return input.y > 0 ? 2 : 0; // Up : Down
        }
    }
    
    private int GetAttackDirection(Vector2 from, Vector2 to)
    {
        Vector2 diff = to - from;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            return diff.x > 0 ? 3 : 1; // Right or Left
        }
        else
        {
            return diff.y > 0 ? 2 : 0; // Up or Down
        }
    }
}