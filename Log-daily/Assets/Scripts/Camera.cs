using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Camera : MonoBehaviour
{
    WebCamTexture webcam;
    [SerializeField] RawImage img, photoTaken, photoInputScene;
    [SerializeField] GameObject retakeScene, takePhotoScene;
    [SerializeField] RectTransform cropArea;
    [SerializeField] TextMeshProUGUI textBug;
  
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

        webcam.requestedWidth = 800; 
        webcam.requestedHeight = 600;
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
       // photo = new Texture2D(webcam.width, webcam.height);

         photo = Crop(webcam, cropArea);

         //photo = Crop2(testImage, cropArea);

        //photo.SetPixels(webcam.GetPixels());
        //photo.Apply();

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



    private Texture2D Crop(WebCamTexture sourceTexture, RectTransform cropRectTransform)
    {
        var cropRect = new RectInt(
            Mathf.FloorToInt(cropRectTransform.position.x),
            Mathf.FloorToInt(cropRectTransform.position.y),
            Mathf.FloorToInt(cropRectTransform.rect.width),
            Mathf.FloorToInt(cropRectTransform.rect.height)
        );


         // Ensure cropRect is within the bounds of sourceTexture
        cropRect.x = Mathf.Clamp(cropRect.x, 0, sourceTexture.width - cropRect.width);
        cropRect.y = Mathf.Clamp(cropRect.y, 0, sourceTexture.height - cropRect.height);

        // Adjust width and height if cropRect exceeds the bounds
        if (cropRect.x + cropRect.width > sourceTexture.width)
        {
            cropRect.width = sourceTexture.width - cropRect.x;
        }
        if (cropRect.y + cropRect.height > sourceTexture.height)
        {
            cropRect.height = sourceTexture.height - cropRect.y;
        }

        var newTexture = new Texture2D(cropRect.width, cropRect.height);

        try
        {
            var newPixels = sourceTexture.GetPixels(cropRect.x, cropRect.y, cropRect.width, cropRect.height);
            newTexture.SetPixels(newPixels);
            newTexture.Apply();
        }
        catch (Exception e)
        {
            // Handle the error and provide feedback
            if (textBug != null)
            {
                textBug.text = e.Message;
            }
          
        }


        //catch (Exception e)
        //{
        //    textBug.text = e.Message;
        //}


        //newTexture.SetPixels(sourceTexture.GetPixels());
 

        return newTexture;
    }


    private Texture2D Crop2(Texture2D sourceTexture, RectTransform cropRectTransform)
    {
        var cropRect = new RectInt(
            Mathf.FloorToInt(cropRectTransform.position.x),
            Mathf.FloorToInt(cropRectTransform.position.y),
            Mathf.FloorToInt(cropRectTransform.rect.width),
            Mathf.FloorToInt(cropRectTransform.rect.height)
        );
       
            var newTexture = new Texture2D(cropRect.width, cropRect.height);
            var newPixels = sourceTexture.GetPixels(cropRect.x, cropRect.y, cropRect.width, cropRect.height);


            newTexture.SetPixels(newPixels);
            newTexture.Apply();
        

     
       
       
        

        return newTexture;
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
