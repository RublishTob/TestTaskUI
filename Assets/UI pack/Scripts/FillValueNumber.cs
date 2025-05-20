using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillValueNumber : MonoBehaviour
{
    public Image TargetImage;
    // Update is called once per frame
    void Update()
    {
        float amount = TargetImage.fillAmount * 100;
        gameObject.GetComponent<TMP_Text>().text = amount.ToString("F0");
    }
}
