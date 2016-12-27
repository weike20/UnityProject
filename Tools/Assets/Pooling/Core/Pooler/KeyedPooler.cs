using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class KeyedPooler<T> :PoolerBase
{
    #region Event
    public Action<Poolable, T> willEnqueueForKey;
    public Action<Poolable, T> didDequeueForKey;
    #endregion

    #region Field / Properties
    public Dictionary<T, Poolable> Collection = new Dictionary<T, Poolable>();
    #endregion

    #region Public
    public bool HasKey(T key)
    {
        return Collection.ContainsKey(key);
    }
    public Poolable GetItem(T key)
    {
        Poolable item = null;
        if (Collection.ContainsKey(key))
            item = Collection[key];
        return item;
    }
    public U GetScript<U> (T key) where U :MonoBehaviour
    {
        Poolable item = GetItem(key);
        return item.GetComponent<U>();
    }
    public virtual void EnqueueByKey(T key)
    {
        Poolable item = GetItem(key);
        if(item != null)
        {
            if (willEnqueueForKey != null)
                willEnqueueForKey(item, key);
            Enqueue(item);
            Collection.Remove(key);
        }
    }
    public virtual Poolable DequeueByKey(T key)
    {
        if (Collection.ContainsKey(key))
            return Collection[key];

        Poolable item = Dequeue();
        Collection.Add(key, item);
        if (didDequeueForKey != null)
            didDequeueForKey(item, key);
        return item;
    }
    public virtual U DequeueScriptByKey<U>(T key) where U:MonoBehaviour
    {
        Poolable item = DequeueByKey(key);
        return item.GetComponent<U>();
    }

    public override void EnqueueAll()
    {
        T[] keys = new T[Collection.Count];
        Collection.Keys.CopyTo(keys, 0);
        for(int i = 0;i != keys.Length ; ++i)
        {
            EnqueueByKey(keys[i]);
        }
    }
    #endregion
}
