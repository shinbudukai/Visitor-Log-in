using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    [SerializeField] Toggle isUsToggleYes, isUsToggleNo;
    [SerializeField] Button printButton;
    string nameInput, companyInput, personVisitingInput, purposeInput;
    bool isUsInputYes, isUsInputNo, isConsentInput;
    bool isEmpty = false;
    private RectTransform FieldPos;

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

    public void UsInputYes(bool isUs)
    {
        isUsInputYes = isUs;
    
        
        Debug.Log(isUsInputYes);
    }

    public void UsInputNo(bool isUs)
    {
        isUsInputNo = isUs;
     
        Debug.Log(isUsInputNo);
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
        FieldPos = gameObject.GetComponent<RectTransform>();
        FieldPos.anchoredPosition = Vector2.zero;
        nameInput = string.Empty;
        companyInput = string.Empty;
        personVisitingInput = string.Empty;
        purposeInput = string.Empty;

        printButton.enabled = false;
        printButton.gameObject.GetComponent<Image>().color = disableColor;
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (isConsentInput && !EmptyStringCheck(nameInput) && !EmptyStringCheck(companyInput) && !EmptyStringCheck(personVisitingInput) && !EmptyStringCheck(purposeInput))
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

    private bool EmptyStringCheck(string s)
    {
        return s == string.Empty;


    }

    public void FieldShifting()
    {
        FieldPos.anchoredPosition = new Vector2(0, 200);
    }

    public void FieldShiftingBack()
    {
        FieldPos.anchoredPosition = Vector2.zero;
    }




}
