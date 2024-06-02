using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteInput : MonoBehaviour
{
    
   private TMP_InputField inputField;
   private Toggle toggle; 

    // Start is called before the first frame update
    void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        toggle = gameObject.GetComponent<Toggle>();
    }

    private void OnDisable()
    {
        if (inputField != null)
        {
            inputField.text = string.Empty;
        }
        

        if(toggle != null)
        {
            toggle.isOn = false;
        }
        
    }
}
