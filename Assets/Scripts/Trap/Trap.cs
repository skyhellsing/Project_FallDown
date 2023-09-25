using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Transform TrapCollider;
    [SerializeField] private TrapTrigger TrapTrigger;
    [SerializeField] private Transform StartPos;
    [SerializeField] private Transform EndPos;
    
    public EffectType Type = EffectType.Impact;
    [SerializeField] private TrapEffect TrapEffect;
    [SerializeField] private float EffectDuration;
    [SerializeField] private float EffectWait;

    private void OnValidate()
    {
        switch (Type)
        {
            case EffectType.Impact:
                TrapEffect = new ImpactEffect(StartPos, EndPos, TrapCollider, EffectDuration, EffectWait);
                TrapTrigger.ClearTrigger();
                TrapTrigger.Trigger += TrapEffect.Do;
                break;
            case EffectType.Move:
                TrapEffect = new MoveEffect(StartPos, EndPos, TrapCollider, EffectDuration, EffectWait);
                TrapTrigger.ClearTrigger();
                TrapTrigger.Trigger += TrapEffect.Do;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum EffectType
{
    Impact,
    Move
}
