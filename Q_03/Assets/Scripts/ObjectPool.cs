using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable] 
public class CustomObjectPool
{
    [SerializeField] private GameObject _pooledObject;
    [SerializeField] private int _poolSize;
    private Stack<PooledBehaviour> _pool;

    public PooledBehaviour TakeFromPool()
    {
        PooledBehaviour target;

        // 새로 추가된 PooledBehaviour도 Pop을 거치도록 변경
        if (_pool.Count == 0)
        {
            AddObject();
            _poolSize++;
        }

        target = _pool.Pop();

        target.gameObject.SetActive(true);
        
        return target;
    }
    
    public void CreatePool()
    {
        _pool = new Stack<PooledBehaviour>(_poolSize);

        for (int i = 0; i < _poolSize; i++)
        {
            AddObject();
        }
    }

    private PooledBehaviour AddObject()
    {
        PooledBehaviour target = MonoBehaviour.Instantiate(_pooledObject).GetComponent<PooledBehaviour>();
        target.Pool = _pool;
        _pool.Push(target);
        target.gameObject.SetActive(false);
        
        return target;
    }
}
