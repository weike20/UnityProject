using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPoolController : MonoBehaviour
{
    #region Fields/Properties
    static GameObjectPoolController Instance
    {
        get
        {
            if (instance == null)
                CreateSharedInstance();
            return instance;
        }
    }

    static GameObjectPoolController instance;

    static Dictionary<string, PoolData> pools = new Dictionary<string, PoolData>();
    #endregion

    #region MonoBehavior
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(instance);
        else
            instance = this;
    }
    #endregion

    #region Public
    /// <summary>
    /// 设置缓存池最大容量
    /// </summary>
    /// <param name="key"></param>
    /// <param name="maxCount"></param>
    public static void SetMaxCount(string key,int maxCount)
    {
        if (!pools.ContainsKey(key))
            return;
        PoolData data = pools[key];
        data.maxCount = maxCount;
    }
    /// <summary>
    /// 增加缓存池
    /// </summary>
    /// <param name="key"></param>
    /// <param name="prefab"></param>
    /// <param name="prepopulate"></param>
    /// <param name="maxCount"></param>
    /// <returns></returns>
    public static bool AddEntry(string key,GameObject prefab,int prepopulate,int maxCount)
    {
        if (pools.ContainsKey(key))
            return false;
        PoolData data = new PoolData();
        data.prefab = prefab;
        data.maxCount = maxCount;
        data.pool = new Queue<Poolable>(prepopulate);
        pools.Add(key, data);

        for(int i= 0 ; i != prepopulate; ++i )
        {
            Enqueue( CreatInstance(key, prefab));
        }

        return true;
    }
    /// <summary>
    /// 清空缓存池
    /// </summary>
    /// <param name="key"></param>
    public static void ClearEntry(string key)
    {
        if (!pools.ContainsKey(key))
            return;
        PoolData data = pools[key];
        while(data.pool.Count>0)
        {
            Poolable obj = data.pool.Dequeue();
            if (obj != null)
                Destroy(obj.gameObject);
        }
        pools.Remove(key);
    }
    /// <summary>
    /// 添加游戏物体到缓存池
    /// </summary>
    /// <param name="sender"></param>
    public static void Enqueue(Poolable sender)
    {
        if (sender == null || sender.isPooled || !pools.ContainsKey(sender.key))
            return;
        PoolData data = pools[sender.key];
        if(data.pool.Count > data.maxCount)
        {
            Destroy(sender.gameObject);
            return;
        }
        data.pool.Enqueue(sender);
        sender.isPooled = true;
        sender.transform.SetParent(Instance.transform);
        sender.gameObject.SetActive(false);

    }
    /// <summary>
    /// 从缓存池取出游戏物体
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static Poolable Dequeue(string key)
    {

        if (!pools.ContainsKey(key))
            return null;
        PoolData data = pools[key];
        if(data.pool.Count ==0)
        {
            return CreatInstance(key, data.prefab);
        }
        Poolable obj = data.pool.Dequeue();
        obj.isPooled = false;
        return obj;

    } 
    #endregion

    #region Private
    static void CreateSharedInstance()
    {
        GameObject go = new GameObject("GameObject Pool Controller");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<GameObjectPoolController>();
    }
    static Poolable CreatInstance(string key,GameObject prefab)
    {
        GameObject instance = Instantiate(prefab) as GameObject;
        Poolable p = instance.AddComponent<Poolable>();
        p.key = key;
        return p;
    }
    #endregion

}
