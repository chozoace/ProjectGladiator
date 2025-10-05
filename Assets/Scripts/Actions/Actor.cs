
using UnityEngine;

public abstract class Actor : MonoBehaviour, IUpdateable
{
    protected Rigidbody2D _rigidBody;

    [SerializeField]
    protected bool _isAttacking = false;

    public bool IsAttacking { get { return _isAttacking; }}

    void Awake()
    {

    }

    public void ExecuteAction(Action action)
    {
        if (action != null)
        {
            action.Execute(gameObject);
        }
    }

    public virtual void AttackStartPrep()
    {
        _rigidBody.linearVelocity = Vector2.zero;
        _isAttacking = true;
    }

    public virtual void EndAttackPrep()
    {
        _isAttacking = false;
    }

    public virtual void UpdateSelf()
    {
        
    }

    public virtual void FixedUpdateSelf()
    {
        
    }
}