
using UnityEngine;

public abstract class Actor : MonoBehaviour, IUpdateable
{
    protected Rigidbody2D _rigidBody;

    [SerializeField]
    protected bool _isAttacking = false;

    [SerializeField]
    protected BoxCollider2D _hurtbox;

    public bool IsAttacking { get { return _isAttacking; } }

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
    public virtual void UpdateSelf()
    {
        
    }

    public virtual void FixedUpdateSelf()
    {
        
    }
}