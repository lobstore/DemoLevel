using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventHandler
{
   public static readonly UnityEvent onWin = new UnityEvent();
   public static readonly UnityEvent onFail = new UnityEvent();
   public static UnityEvent<Rigidbody2D> onDoorTrigger = new UnityEvent<Rigidbody2D>();

}
