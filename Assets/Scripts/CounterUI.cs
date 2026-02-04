using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private CounterController _controller;
    [SerializeField] private TextMeshProUGUI _counterTMP;

    private void OnEnable()
    {
        _controller.CounterChanged += UpdateTimer;
    }

    private void OnDisable()
    {
        _controller.CounterChanged -= UpdateTimer;
    }

    private void UpdateTimer(int value)
    {
        _counterTMP.text = value.ToString();
    }
}
