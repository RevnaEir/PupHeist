using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDialogeActorImage : MonoBehaviour
{
    [SerializeField] private Image dialogeImage;


    public void ChangeImage(Sprite img)
    {
        dialogeImage.sprite = img;
    }

}
