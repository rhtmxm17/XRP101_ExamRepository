using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            // 대상이 적이 아닐경우 예외 처리
            if (col.CompareTag("Player"))
                continue;

            // 대상이 IDamagable를 가지고 있을 경우에만 TakeHit 호출
            if (col.TryGetComponent(out damagable))
            {
                damagable.TakeHit(Controller.AttackValue);
            }
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        Exit();
    }

}
