using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    WebCamTexture webcam;
    [SerializeField] RawImage img, photoTaken, photoInputScene;
    [SerializeField] GameObject retakeScene, takePhotoScene;
    Texture2D photo;
    Animator takePhotoSceneAnim;

    private void Start()
    {
        webcam = new WebCamTexture();
        takePhotoSceneAnim = takePhotoScene.GetComponent<Animator>();


        if (Application.platform == RuntimePlatform.Android)
        {
            webcam = new WebCamTexture(WebCamTexture.devices[1].name);
        }
    }

    public void TurnOnCamera()
    {

        webcam.Stop();
        img.gameObject.SetActive(true);  
        img.texture = webcam;
        webcam.Play();

    }

    IEnumerator TakePhotoIE()
    {
        // Wait for the end of the current frame
        yield return new WaitForEndOfFrame();

        // Create a Texture2D to store the photo
        photo = new Texture2D(webcam.width, webcam.height);
        photo.SetPixels(webcam.GetPixels());
        photo.Apply();

        // Encode the photo to PNG format
        byte[] bytes = photo.EncodeToPNG();

        // Save the PNG to a file (replace 'your_path' with the desired location)
        //File.WriteAllBytes(your_path + "photo.png", bytes);
        if (photoTaken != null && photo != null)
        {
            photoTaken.texture = photo; // Assign the photo texture to the RawImage
            photoInputScene.texture = photo;
        }

    }

    public void TakePhoto()
    {
        StartCoroutine(TakePhotoIE());
        img.gameObject.SetActive(false);
        takePhotoScene.SetActive(false);

        takePhotoSceneAnim.enabled = true;
        retakeScene.SetActive(true);
        

    }

    public void Retake()
    {
         
        takePhotoSceneAnim.enabled = false;


        webcam.Stop();
        retakeScene.SetActive(false);
        takePhotoScene.SetActive(true);
        img.gameObject.SetActive(true);
        img.texture = webcam;
        webcam.Play();
    }

}
