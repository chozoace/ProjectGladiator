using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObjects/Attack", order = 0)]
public class Attack : ScriptableObject, Action
{
    [SerializeField]
    int damage;

    Actor _attackerRef;

    private Animator _anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        if (!_attackerRef.IsAttacking)
        {
           _anim.SetBool("attacking", false);
        }
    }

    public void Execute(GameObject obj)
    {
        _attackerRef = obj.GetComponent<Actor>();
        _anim = obj.GetComponent<Animator>();
        StartAttack();
    }

    private void StartAttack()
    {

    }

    private void EndAttack()
    {
        _anim.SetBool("attacking", false);
    }

    public string GetActionName()
    {
        throw new System.NotImplementedException();
    }
}
