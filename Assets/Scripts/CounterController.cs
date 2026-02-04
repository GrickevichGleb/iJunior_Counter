using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private int _step;
    
    public event Action<int> CounterChanged;
    
    private int _counterValue = 0;
    private bool _isCounting = true;

    private void Start()
    {
        CounterChanged?.Invoke(_counterValue);
        StartCoroutine(CountTime(_interval, _step));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isCounting = !_isCounting;
    }
    
    private IEnumerator CountTime(float interval, int step = 1)
    {
        var waitInstruction = new WaitForSeconds(interval);

        while (true)
        {
            if (_isCounting)
            {
                yield return waitInstruction;

                _counterValue += step;
                CounterChanged?.Invoke(_counterValue);
            }
            else
            {
                yield return null;
            }
        }
    }
}