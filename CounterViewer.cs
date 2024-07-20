using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;
  
    private void Start()
    {
        _text.text = _counter.Value.ToString("");
    }

    private void OnEnable()
    {
        _counter.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = value.ToString("");
    }
}
