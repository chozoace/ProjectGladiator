using UnityEngine;

public class PlayerCombatScript : Fighter
{
    public bool _lockControls = false;

    [SerializeField]
    Attack downAttack;
    [SerializeField]
    Attack leftAttack;
    [SerializeField]
    Attack upAttack;
    [SerializeField]
    Attack rightAttack;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

    public override void EndAttack()
    {
        _lockControls = false;
        base.EndAttack();
    }

    public override void FixedUpdateSelf()
    {

    }

    public override void UpdateSelf()
    {

    }

    public void disableAnimator()
    {
        _anim.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public void enableAnimator()
    {
        _anim.enabled = true;
        _spriteRenderer.enabled = true;
    }
}