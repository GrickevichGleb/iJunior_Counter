using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [Space]
    [SerializeField] private float _interval;
    [SerializeField] private int _step;
    
    public event Action<int> ValueChanged;
    
    private int _counterValue = 0;
    private bool _isCounting = true;

    private Coroutine _countTimeCoroutine;

    private void OnEnable()
    {
        _inputReader.MouseClicked += OnMouseClicked;
    }

    private void Start()
    {
        ValueChanged?.Invoke(_counterValue);
        _countTimeCoroutine = StartCoroutine(CountTime(_interval, _step));
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= OnMouseClicked;
    }
    
    private void OnMouseClicked()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
            _countTimeCoroutine = StartCoroutine(CountTime(_interval, _step));
        else if(_countTimeCoroutine != null)
            StopCoroutine(_countTimeCoroutine);
    }

    private IEnumerator CountTime(float interval, int step = 1)
    {
        var waitInstruction = new WaitForSeconds(interval);

        while (_isCounting)
        {
            yield return waitInstruction;

            _counterValue += step;
            ValueChanged?.Invoke(_counterValue);
        }
    }

    

    
}