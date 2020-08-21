using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorImage : MonoBehaviour
{
    public Image[] images;

    private void OnMouseOver()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(0, 255, 13); ;
        }
    }
}
