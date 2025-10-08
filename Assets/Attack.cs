using UnityEngine;

public class Attack : MonoBehaviour, Action
{
    [SerializeField]
    int damage;

    Actor _attackerRef;
    PlayerCombatScript _combatScriptRef;

    private Animator _anim;

    public void FixedUpdate()
    {
        if (!_attackerRef.IsAttacking)
        {
           //_anim.SetBool("attacking", false);
        }
    }

    public void Execute(GameObject obj)
    {
        _attackerRef = obj.GetComponent<Actor>();
        _anim = obj.GetComponent<Animator>();
        _combatScriptRef = obj.GetComponent<PlayerCombatScript>();
        StartAttack();
    }

    public void StartAttack()
    {
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
        _combatScriptRef.disableAnimator();
    }

    public void EndAttack()
    {
        _combatScriptRef.EndAttack();
        _combatScriptRef.enableAnimator();
        Destroy(this);
    }

    public string GetActionName()
    {
        return null;
    }
}
