using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public abstract class TrapEffect
{
    protected Vector3 StartPos;
    protected Vector3 EndPos;
    protected Transform Collider;
    protected float Duration;
    protected float Wait;
    
    public TrapEffect(Transform startPos, Transform endPos, Transform collider, float duration, float wait)
    {
        StartPos = startPos.localPosition;
        EndPos = endPos.localPosition;
        Collider = collider;
        Duration = duration;
        Wait = wait;
    }
    
    public abstract void Do();
    public abstract void Reset();
}

[Serializable]
public class ImpactEffect : TrapEffect
{
    public ImpactEffect(Transform startPos, Transform endPos, Transform collider, float duration, float wait) : base(startPos, endPos, collider, duration, wait)
    {
    }

    public override void Do()
    {
        Debug.Log("Do ImpactEffect");
        Collider.DOLocalMove(EndPos, Duration).SetDelay(Wait);
    }

    public override void Reset()
    {
        Debug.Log("Reset ImpactEffect");
        Collider.localPosition = StartPos;
    }
}

[Serializable]
public class MoveEffect : TrapEffect
{
    public MoveEffect(Transform startPos, Transform endPos, Transform collider, float duration, float wait) : base(startPos, endPos, collider, duration, wait)
    {
    }
    
    public override void Do()
    {
        Debug.Log("Do MoveEffect");
        
        Collider.DOLocalMove(EndPos, Duration).SetDelay(Wait);
    }

    public override void Reset()
    {
        Debug.Log("Reset ImpactEffect");
        Collider.localPosition = StartPos;
    }
}