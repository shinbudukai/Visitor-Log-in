using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteInput : MonoBehaviour
{
    
    private Component _inputField;
    
    private Toggle _toggle; 




    // Start is called before the first frame update
    void Start()
    {
        _inputField = gameObject.GetComponent<TMP_InputField>();
        if (_inputField == null )
        {
            _inputField = gameObject.GetComponent<InputField>();
        }

        _toggle = gameObject.GetComponent<Toggle>();
    }

    private void OnDisable()
    {
        //handle two type of fields
        if (_inputField != null)
        {
            if (_inputField is TMP_InputField tmpInputField)
            {
                tmpInputField.text = string.Empty;
            }
            else if (_inputField is InputField inputField)
            {
                inputField.text = string.Empty;
            }
        }
        

        if(_toggle != null)
        {
            _toggle.isOn = false;
        }
        
    }
}
