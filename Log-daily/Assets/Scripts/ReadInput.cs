using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class ReadInput : MonoBehaviour
{
    [SerializeField] Toggle isUsToggleYes, isUsToggleNo;
    [SerializeField] Button printButton;
    [SerializeField] ListHandle listHandle;

    string nameInput, companyInput, personVisitingInput, purposeInput;
    bool isUsInputYes = true;  //The check default is Yes
    bool isUsInputNo, isConsentInput;
    public string tempInfor { get; private set; }


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

    private string getUsStatus()
    {
        if (isUsInputYes)
        {
            return "Yes";
        }

        else return "No";
        
    }

    //For print label button
    public void getVisitor()
    {
        Visitor visitor = new Visitor(nameInput, companyInput, getUsStatus());
        Debug.Log(visitor.GetInfor());

        listHandle.AddItem(visitor);
        tempInfor = $"{visitor.vName} | {visitor.vCompany} | Us: {visitor.vIsUs}";

    }
    



    public class Visitor
    {
        public string vName { get; private set; }
        public string vCompany { get; private set; }
        public string vIsUs { get; private set; }

        public Visitor(string name, string company, string isUs)
        {
            this.vName = name;
            this.vCompany = company;
            this.vIsUs = isUs;
        }


        public string GetInfor()
        {
            string temp = $"{vName} | {vCompany} | Us: {vIsUs}";
            return temp;
        }

        public string GetVisitorName()
        {
            return vName;
        }

    }


}

//Make this class derive from Mono so it can be Serialized and showed in the inpsector

