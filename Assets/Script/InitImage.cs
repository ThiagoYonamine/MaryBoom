using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitImage : MonoBehaviour
{
    private Image image;
    private Color tempColor;
    static float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        tempColor = image.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempColor.a = Mathf.Lerp(100, 0, t)/100f;
        // .. and increase the t interpolater
        t += Time.deltaTime/1.5f;
        image.color = tempColor;

        if (tempColor.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
