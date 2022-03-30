using UnityEngine;
using Sirenix.OdinInspector;

public abstract class GameEventDecorator : IGameEvent
{
    [SerializeField, Required]
    private IGameEvent _event;

    public virtual void Trigger()
    {
        _event.Trigger();
    }
}

