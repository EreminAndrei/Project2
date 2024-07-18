using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isActive;
    private int _value;

    private void Start()
    {
        _value = 0;
        DisplayCounter(_value);        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            if (_isActive == false) 
            {  
                _isActive = true;
                StartCoroutine(Count(_delay, _value));
            }
            else
            {
                StopAllCoroutines();
                _isActive = false;
            }
        }
    }

    private IEnumerator Count(float delay, int value)
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(delay);
            _value++;
            DisplayCounter(_value);            
        }
    }

    private void DisplayCounter(int value)
    {
        _text.text = _value.ToString("");
    }


     
}
