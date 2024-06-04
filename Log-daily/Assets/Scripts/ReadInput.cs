using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    [SerializeField] Button printButton;
    string nameInput, companyInput, personVisitingInput, purposeInput;
    bool isUsInput, isConsentInput;
    bool isEmpty = false;

    private Color disableColor = Color.grey;
    private Color enableColor = Color.white;
    
    public void GetNameInput(string name)
    {
        nameInput = name;
        Debug.Log(nameInput);
        
    }

    public void CompanyInput(string company)
    {
        companyInput = company;
        Debug.Log(companyInput);
    }

    public void PersonVisitingInput(string personVisiting)
    {
        personVisitingInput = personVisiting;
        Debug.Log(personVisitingInput);
    }

    public void UsInput(bool isUs)
    {
        isUsInput = isUs;
        Debug.Log(isUsInput);
    }

    public void ConsentInput(bool isConsent)
    {
        isConsentInput = isConsent;
        Debug.Log(isConsentInput);
    }

    public void PurposeInput(string purpose)
    {
        purposeInput = purpose;
        Debug.Log(purposeInput);
    }

    private void Start()
    {
        nameInput = string.Empty;
        companyInput = string.Empty;

        printButton.enabled = false;
        printButton.gameObject.GetComponent<Image>().color = disableColor;
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (isConsentInput && !EmptyStringCheck(nameInput) && !EmptyStringCheck(companyInput))
        {
            printButton.gameObject.GetComponent<Image>().color = enableColor;
            printButton.enabled = true;
        }

        else
        {
            printButton.gameObject.GetComponent<Image>().color = disableColor;
            printButton.enabled = false;
        }
    }

    public bool EmptyStringCheck(string s)
    {
        return s == string.Empty;


    }


   

}
