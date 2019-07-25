using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    private float faderSetting;
    private Image fader;

	// Use this for initialization
	void Start () {
        fader = GetComponent<Image>();
        faderSetting = 1;
        fader.color = new Color(0, 0, 0, faderSetting);
        setFaderOpacity(0);
	}

    public void setFaderOpacity(float valueToSet)
    {
        StartCoroutine(fade(valueToSet));
    }

    public float getFaderOpacity()
    {
        return fader.color.a;
    }

    private IEnumerator fade(float fadeTo)
    {
        float changeFrom = fader.color.a;
        if (changeFrom > fadeTo)
        {
            while (changeFrom > fadeTo)
            {
                changeFrom -= 0.01f;
                fader.color = new Color(0, 0, 0, changeFrom);
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (changeFrom < fadeTo)
            {
                changeFrom += 0.01f;
                fader.color = new Color(0, 0, 0, changeFrom);
                yield return new WaitForEndOfFrame();
            }
        }
        fader.color = new Color(0, 0, 0, fadeTo);
    }
}
