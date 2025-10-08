using UnityEngine;

public class AttackScript : MonoBehaviour, IUpdateable
{
    private BoxCollider2D _hitbox;
    public bool _attackActive;

    public void StartAttack()
    {
        this.enabled = true;
    }

    public void EndAttack()
    {
        this.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Attack inflicted");
    }

    public void FixedUpdateSelf()
    {

    }

    public void UpdateSelf()
    {
        
    }
}