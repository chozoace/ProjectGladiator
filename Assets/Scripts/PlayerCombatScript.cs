using UnityEngine;

public class PlayerCombatScript : MonoBehaviour, IUpdateable
{
    [SerializeField]
    public bool _isAttacking;

    public bool _lockControls = false;

    [SerializeField]
    Attack downAttack;
    [SerializeField]
    Attack leftAttack;
    [SerializeField]
    Attack upAttack;
    [SerializeField]
    Attack rightAttack;

    Attack _currentAttack;

    Animator _anim;
    SpriteRenderer _spriteRenderer;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartAttack(int inputDir)
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
        Debug.Log("combat start");
        _currentAttack.Execute(gameObject);
    }

    public void EndAttack()
    {
        Debug.Log("combat script end");
        _isAttacking = false;
        _lockControls = false;
    }

    public void FixedUpdateSelf()
    {

    }

    public void UpdateSelf()
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