using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

public class ArrowScript : MonoBehaviour {

    private IEnumerator movingArrowCoroutine;

    private SliderScript sliderScript;

    public void BeginMovingArrow(SliderScript newSliderScript) {
        if (movingArrowCoroutine == null) {
            sliderScript = newSliderScript;
            movingArrowCoroutine = MovingArrowCoroutine();
            StartCoroutine(movingArrowCoroutine);
        }
    }

    public void StopMovingArrow() {
        if (movingArrowCoroutine != null) {
            StopCoroutine(movingArrowCoroutine);
            movingArrowCoroutine = null;
        }
    }

    private IEnumerator MovingArrowCoroutine() {
        while (true) {
            float relativePositionY = sliderScript.getCurrentValue().Map(sliderScript.getMinValue(),
                                      sliderScript.getMaxValue(), -2, 2);
            transform.localPosition = new Vector2(transform.localPosition.x, relativePositionY);
            yield return null;
        }
    }
}
