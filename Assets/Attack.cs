using UnityEngine;

public class Attack : MonoBehaviour, Action
{
    [SerializeField]
    int damage = 5;

    [SerializeField]
    float hitStunTime = 1;

    Fighter _combatScriptRef;

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
        _anim = obj.GetComponent<Animator>();
        _combatScriptRef = obj.GetComponent<Fighter>();
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
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Fighter actor = collision.transform.parent.GetComponent<Fighter>();
        actor.TakeDamage(damage, hitStunTime);
    }

    public string GetActionName()
    {
        return null;
    }
}
