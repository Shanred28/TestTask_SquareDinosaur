using System;
using UnityEngine;

namespace Services.Interfaces
{
    public interface  IInputService
    {
        Vector2 MoveDirection { get; }
        Vector2 LookDelta { get; }
        event Action OnSpawnRequest;
        event Action OnSendMessage;
    }
}
