
public class EnemyCombatScript : Fighter
{
    EnemyState _currentState;

    protected override void Start()
    {
        _currentState = new EnemyAttackState(this);
        _currentState.Enter();
        base.Start();
    }

    public void ChangeState(EnemyState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public override void TakeDamage(int damage, float hitstunDuration)
    {
        if (!_hitstun)
        {
            EnterHitstun(hitstunDuration);
            base.TakeDamage(damage, hitstunDuration);
        }
    }

    public override void UpdateSelf()
    {
        _currentState.UpdateState();
        if (health < 1)
        {
            world.RemoveFromWorld(this);
            Destroy(gameObject);
        }
        base.UpdateSelf();
    }

    public override void FixedUpdateSelf()
    {
        _currentState.FixedUpdateState();
        base.FixedUpdateSelf();
    }
}