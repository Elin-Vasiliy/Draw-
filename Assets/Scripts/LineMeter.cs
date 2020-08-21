using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineMeter : MonoBehaviour
{
    public TMP_Text text;

    private Image meter;

    void Start()
    {
        meter = GetComponent<Image>();
    }

    void Update()
    {
        meter.fillAmount = 1 - (LinesDrawer.instance.lineLength / LinesDrawer.instance.maxLineLength);
        text.text = Mathf.Round((meter.fillAmount * 100)).ToString() + "%";
    }
}
