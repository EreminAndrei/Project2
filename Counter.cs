using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;

    public event Action<int> ValueChanged;

    private Coroutine _coroutine;
    private bool _isActive;    

    public int Value { get; private set; }

    private void Start()
    {
        _isActive = false;
        Value = 0;       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            if (_isActive == false) 
            {  
                _isActive = true;                
                _coroutine = StartCoroutine(Count(_delay, Value));
            }
            else
            {
                StopCoroutine(_coroutine);
                _isActive = false;
            }
        }
    }

    private IEnumerator Count(float delay, int value)
    {
        var wait = new WaitForSeconds(delay);
        
        while (_isActive)
        {
            yield return wait;
            Value++;
            ValueChanged?.Invoke(Value);                                  
        }
    }         
}
