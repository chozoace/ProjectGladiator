using UnityEngine;

public class Attack : MonoBehaviour, Action
{
    [SerializeField]
    int damage;

    Actor _attackerRef;
    PlayerCombatScript _combatScriptRef;

    private Animator _anim;

    [SerializeField]
    bool _attackFinished;

    void Start()
    {
        _attackFinished = false;
    }

    public void FixedUpdate()
    {
        if (_attackFinished)
        {
            EndAttack();
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
        Debug.Log("attack log start");
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
        _combatScriptRef.disableAnimator();
    }

    public void EndAttack()
    {
        Debug.Log("attack log end");
        _combatScriptRef.EndAttack();
        _combatScriptRef.enableAnimator();
        Destroy(this.gameObject);
    }

    public string GetActionName()
    {
        return null;
    }
}
