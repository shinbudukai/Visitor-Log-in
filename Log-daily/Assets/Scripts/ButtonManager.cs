using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject welcomeScence, takephotoScene, retakeScene, inputScene, signOutScene;
   

    private void Start()
    {
        //Begin at the home screen
        HomeButton();
    }

    public void SignInButton()
    {
        welcomeScence.SetActive(false);
        takephotoScene.SetActive(true);

    }

    public void NextToInputFieldButton()
    {
        takephotoScene.SetActive(false);
        retakeScene.SetActive(false);
        inputScene.SetActive(true);

    }

    public void HomeButton()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        welcomeScence.SetActive(true);

    }

    public void BackToPhotoButton()
    {
        inputScene.SetActive(false);
        retakeScene.SetActive(true);
        takephotoScene.SetActive(true);
    }

    public void SignOutButton()
    {
        welcomeScence.SetActive(false);
        signOutScene.SetActive(true);
    }



}
