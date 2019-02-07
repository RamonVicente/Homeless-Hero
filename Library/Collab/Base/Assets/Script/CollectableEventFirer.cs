using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableEventFirer : MonoBehaviour {

    public delegate void CollectionAction();
    public event CollectionAction onCollection;

    void Collected()
    {
        onCollection?.Invoke();
    }
}