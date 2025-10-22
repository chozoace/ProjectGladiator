
using System.Collections;
using UnityEngine;

public abstract class Fighter : MonoBehaviour, IUpdateable
{
    protected Rigidbody2D _rigidBody;
    protected Animator _anim;
    public bool _lockControls = false;

    [SerializeField]
    protected bool _isAttacking = false;

    public bool IsAttacking { get { return _isAttacking; }}

    [SerializeField]
    protected BoxCollider2D _hurtbox;

    public int health = 10;

    public float _fighterSpeed = 4;

    [SerializeField]
    protected bool _hitstun = false;

    public bool Hitstun { get { return _hitstun; }}

    [SerializeField]
    protected GameWorld world;

    protected Attack _currentAttack;

    protected SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        world.AddToWorld(this);
    }

    public void ExecuteAction(Action action)
    {
        if (action != null)
        {
            action.Execute(gameObject);
        }
    }
    public virtual void UpdateSelf()
    {
        
    }

    public virtual void FixedUpdateSelf()
    {

    }

    public virtual void TakeDamage(int damage, float hitstunDuration)
    {
        health -= damage;
    }

    public virtual void ApplyAttackForce(Vector2 force)
    {

    }

    public virtual void EnterHitstun(float hitstunTime)
    {
        StopAllCoroutines();
        _hitstun = true;
        if (_isAttacking && _currentAttack != null)
        {
            _currentAttack.EndAttack();
        }

        _anim.SetBool("hitstun", true);
        StartCoroutine(ExitHitstun(hitstunTime));
    }

    public virtual IEnumerator ExitHitstun(float hitstunTime)
    {
        yield return new WaitForSeconds(hitstunTime);
        _hitstun = false;
        _anim.SetBool("hitstun", false);
    }

    public virtual void StartAttack(int inputDir)
    {

    }
    
    public virtual void EndAttack()
    {
        _isAttacking = false;
    }

    public virtual void disableAnimator()
    {
        _anim.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public virtual void enableAnimator()
    {
        _anim.enabled = true;
        _spriteRenderer.enabled = true;
    }

}