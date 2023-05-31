using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeIN : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEnable()
    {
        Image img = GetComponent<Image>();
        TMP_Text txt = GetComponent<TextMeshProUGUI>();
        if(txt) StartCoroutine(FadeIn(1, txt));
        else StartCoroutine(FadeIn(1, img));
    }

    private IEnumerator FadeIn(float time, TMP_Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            Debug.Log("Changing text");
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.unscaledDeltaTime / time));
            yield return null;
        }
    }
    private IEnumerator FadeIn(float time, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            Debug.Log("Changing image");
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.unscaledDeltaTime / time));
            yield return null;
        }
    }
}
