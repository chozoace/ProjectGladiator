using System.Collections;
using UnityEngine;

public class PlayerCombatScript : Fighter
{
    [SerializeField]
    Attack downAttack;
    [SerializeField]
    Attack leftAttack;
    [SerializeField]
    Attack upAttack;
    [SerializeField]
    Attack rightAttack;

    [SerializeField]
    GameController gameController;

    protected override void Awake()
    {
        base.Awake();
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
        _rigidBody.linearVelocity = Vector2.zero;
        _lockControls = true;
        base.EnterHitstun(hitstunTime);
    }

    public override IEnumerator ExitHitstun(float hitstunTime)
    {
        yield return StartCoroutine(base.ExitHitstun(hitstunTime));
        _lockControls = false;
    }

    public override void EndAttack()
    {
        _lockControls = false;
        base.EndAttack();
    }

    public override void FixedUpdateSelf()
    {
        base.FixedUpdateSelf();
    }

    public override void UpdateSelf()
    {
        base.UpdateSelf();
    }

    public override void StartDeath()
    {
        StopAllCoroutines();
        if (_isAttacking && _currentAttack != null)
        {
            _currentAttack.EndAttack();
        }
        _lockControls = true;
        _dead = true;
        _anim.SetBool("death", true);
        _anim.SetBool("hitstun", false);
        gameController.StartDeath();
    }
}