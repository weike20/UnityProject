using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class IndexedPooler : PoolerBase
{
    #region Event
    public Action<Poolable, int> willEqueueAtIndex;
    public Action<Poolable, int> didEqueueAtIndex;
    #endregion

    #region Fields / Properties
    public List<Poolable> Collection = new List<Poolable>();
    #endregion

    #region Public
    public Poolable GetItem(int index)
    {
        if (index < 0 || index >= Collection.Count)
            return null;
        return Collection[index];
    }
    public T GetScript<T> (int index) where T:MonoBehaviour
    {
        Poolable item = GetItem(index);
        if (item != null)
            return item.GetComponent<T>();
        return null;
    }
    public void EnqueueByIndex(int index)
    {
        Poolable item = GetItem(index);
        if (item != null)
            Enqueue(item);
    }
    public override void Enqueue(Poolable item)
    {
        base.Enqueue(item);
        int index = Collection.IndexOf(item);
        if (index != -1)
        {
            if (willEqueueAtIndex != null)
                willEqueueAtIndex(item, index);
            Collection.RemoveAt(index);
        }
    }
    public override Poolable Dequeue()
    {
        Poolable item = base.Dequeue();
        Collection.Add(item);
        if(didEqueueAtIndex != null)
            didEqueueAtIndex(item, Collection.Count - 1);
        return item;
    }
    public override void EnqueueAll()
    {
        for(int i=Collection.Count -1;i >= 0; --i )
        {
            Enqueue(Collection[i]);
        }
    }
    #endregion
}
