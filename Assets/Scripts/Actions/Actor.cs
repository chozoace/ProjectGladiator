
using System.Collections;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IUpdateable
{
    protected Rigidbody2D _rigidBody;
    protected Animator _anim;

    [SerializeField]
    protected bool _isAttacking = false;

    [SerializeField]
    protected BoxCollider2D _hurtbox;

    public bool IsAttacking { get { return _isAttacking; } }

    public int health = 10;

    [SerializeField]
    protected bool _hitstun = false;

    [SerializeField]
    protected GameWorld world;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
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

    public void EnterHitstun(float hitstunTime)
    {
        StopAllCoroutines();
        _hitstun = true;
        if (_isAttacking)
        {
            //combat script attack finished test
        }

        _anim.SetBool("hitstun", true);
        StartCoroutine(ExitHitstun(hitstunTime));
    }

    IEnumerator ExitHitstun(float hitstunTime)
    {
        yield return new WaitForSeconds(hitstunTime);
        _hitstun = false;
        _anim.SetBool("hitstun", false);
    }

}