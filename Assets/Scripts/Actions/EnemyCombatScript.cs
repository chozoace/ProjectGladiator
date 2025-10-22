
using System.Collections;
using UnityEngine;

public class EnemyCombatScript : Fighter
{
    EnemyState _currentState;

    [SerializeField]
    Attack downAttack;
    [SerializeField]
    Attack leftAttack;
    [SerializeField]
    Attack upAttack;
    [SerializeField]
    Attack rightAttack;

    protected override void Start()
    {
        _currentState = new EnemyHuntState(this);
        _currentState.Enter();
        base.Start();
    }

    public void ChangeState(EnemyState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public override void TakeDamage(int damage, float hitstunDuration)
    {
        if (!_hitstun)
        {
            EnterHitstun(hitstunDuration);
            base.TakeDamage(damage, hitstunDuration);
        }
    }

    public override void EnterHitstun(float hitstunTime)
    {
        ChangeState(new EnemyHitstunState(this));
        base.EnterHitstun(hitstunTime);
    }

    public override IEnumerator ExitHitstun(float hitstunTime)
    {
        yield return StartCoroutine(base.ExitHitstun(hitstunTime));
        ChangeState(new EnemyHuntState(this));
    }

    public override void StartAttack(int inputDir)
    {
        _isAttacking = true;
        _lockControls = true;
        switch (inputDir)
        {
            case 0:
                _currentAttack = Instantiate(downAttack, gameObject.transform);
                break;
            case 1:
                _currentAttack = Instantiate(leftAttack, gameObject.transform);
                break;
            case 2:
                _currentAttack = Instantiate(upAttack, gameObject.transform);
                break;
            case 3:
                _currentAttack = Instantiate(rightAttack, gameObject.transform);
                break;
        }
        _currentAttack.Execute(gameObject);
        base.StartAttack(inputDir);
    }

    public override void UpdateSelf()
    {
        _currentState.UpdateState();
        if (health < 1)
        {
            world.RemoveFromWorld(this);
            Destroy(gameObject);
        }
        base.UpdateSelf();
    }

    public override void FixedUpdateSelf()
    {
        _currentState.FixedUpdateState();
        base.FixedUpdateSelf();
    }
}