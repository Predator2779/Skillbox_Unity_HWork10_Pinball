using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] public int _counter = 0;
    [SerializeField] private Text _text;

    void Update()
    {
        _text.text = $"—четик очков: {_counter}";
    }
}
