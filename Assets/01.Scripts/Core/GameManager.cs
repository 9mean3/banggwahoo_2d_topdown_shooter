using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private PoolingListSO _poolingList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is running! Check!");
        }
        Instance = this;

        TimeController.Instance = transform.AddComponent<TimeController>();

        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform); //풀매니저 만들기
        _poolingList.list.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
         //총알 풀 완성
    }
}
