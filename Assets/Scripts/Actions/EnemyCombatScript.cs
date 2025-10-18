
public class EnemyCombatScript : Fighter
{
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
        if (health < 1)
        {
            world.RemoveFromWorld(this);
            Destroy(gameObject);
        }
    }
}