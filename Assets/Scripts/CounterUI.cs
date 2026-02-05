using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Counter _controller;
    [SerializeField] private TextMeshProUGUI _counterTMP;

    private void OnEnable()
    {
        _controller.ValueChanged += UpdateTimer;
    }

    private void OnDisable()
    {
        _controller.ValueChanged -= UpdateTimer;
    }

    private void UpdateTimer(int value)
    {
        _counterTMP.text = value.ToString();
    }
}
