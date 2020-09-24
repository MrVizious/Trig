using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentValueScript : MonoBehaviour {

    private Text text;
    private IEnumerator changingValueDisplayedCoroutine;
    private SliderScript sliderScript;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void setValueDisplayed(int newValueDisplayed) {
        text.text = newValueDisplayed.ToString();
    }

    public void BeginChangingValueDisplayed(SliderScript newSliderScript) {
        if (changingValueDisplayedCoroutine == null) {
            sliderScript = newSliderScript;
            changingValueDisplayedCoroutine = ChangingValueDisplayedCoroutine();
            StartCoroutine(changingValueDisplayedCoroutine);
        }
    }

    public void StopChangingValueDisplayed() {
        if (changingValueDisplayedCoroutine != null) {
            StopCoroutine(changingValueDisplayedCoroutine);
        }

        changingValueDisplayedCoroutine = null;
    }

    private IEnumerator ChangingValueDisplayedCoroutine() {
        while (true) {
            yield return null;
            text.text = ((int) sliderScript.getCurrentValue()).ToString();
        }
    }
}
