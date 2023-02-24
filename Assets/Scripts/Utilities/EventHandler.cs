using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bag;

public static class EventHandler
{
    public static event Action<ItemDetails, int> UpdateUIEvent;

    public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        UpdateUIEvent?.Invoke(itemDetails, index);
    }
}