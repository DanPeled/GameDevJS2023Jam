using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly Func<T> factoryMethod;
    private readonly Action<T> resetMethod;

    private readonly Queue<T> pool = new Queue<T>();

    public ObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null)
    {
        this.factoryMethod = factoryMethod;
        this.resetMethod = resetMethod ?? (obj => { });
    }

    public T GetObject()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        return factoryMethod();
    }

    public void ReturnObject(T obj)
    {
        resetMethod(obj);
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
