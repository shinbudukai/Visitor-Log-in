using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    string nameInput, companyInput, personVisitingInput, purposeInput;
    bool isUsInput, isConsentInput;
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


}
