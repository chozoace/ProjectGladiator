using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : Actor
{
    [SerializeField] float _moveSpeed = 5;
    private PlayerCombatScript _combatScript;

    private int currentDir;
    public bool lockControls = false;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _combatScript = GetComponent<PlayerCombatScript>();
        world.AddToWorld(this);
    }

    public void AttackFinished()
    {
        _anim.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void UpdateSelf()
    {
        Vector2 dir = Vector2.zero;
        if (!_combatScript._lockControls)
        {
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                currentDir = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                currentDir = 3;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                currentDir = 2;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                currentDir = 0;
            }

            if (Input.GetKey(KeyCode.J))
            {
                if (!_isAttacking)
                {
                    _combatScript.StartAttack(currentDir);
                }
            }
        }

        dir.Normalize();
        _rigidBody.linearVelocity = _moveSpeed * dir;
        _anim.SetInteger("direction", currentDir);
        _anim.SetFloat("speed", _rigidBody.linearVelocity.magnitude);
        base.UpdateSelf();
    }

    public override void FixedUpdateSelf()
    {
        base.FixedUpdateSelf();
    }
}
