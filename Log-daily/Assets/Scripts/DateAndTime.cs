using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class DateAndTime : MonoBehaviour
{
    DateTime dt;
    TextMeshProUGUI dtText;

    // Start is called before the first frame update
    void Start()
    {
        dtText = gameObject.GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        DateTimeUpdate();
    }

    private void DateTimeUpdate()
    {
        dt = DateTime.Now;
        dtText.text = dt.ToString("ddd MM/dd/yy hh:mm tt");

    }
}
