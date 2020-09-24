using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour {

    private const int MAX_VALUE_CAP = 200;
    private const int MIN_VALUE_CAP = -200;
    private const int MAX_SPEED = 2;

    private int maxValue, minValue;
    private float speed,  currentValue;

    private IEnumerator changingCurrentValueCoroutine;

    void Start() {
        RandomizeMaxAndMinValues();
        RandomizeSpeed();
        currentValue = minValue + (maxValue - minValue) / 2;
    }

    public void RandomizeMaxAndMinValues() {

        int a = Random.Range(MIN_VALUE_CAP, MAX_VALUE_CAP);
        int b = Random.Range(MIN_VALUE_CAP, MAX_VALUE_CAP);

        if (a == b) {
            //Debug.Log("Randomizing");
            RandomizeMaxAndMinValues();
        } else if (a > b) {
            //Debug.Log(a + " is greater than " + b);
            maxValue = a;
            minValue = b;
        } else if (b > a) {
            //Debug.Log(b + " is greater than " + a);
            maxValue = b;
            minValue = a;
        }

    }

    public void RandomizeSpeed() {
        speed = Random.Range((float) - MAX_SPEED, (float)MAX_SPEED);
    }

    public void BeginChangingCurrentValue() {
        Debug.Log("Coroutine for current value change has started!");

        if (changingCurrentValueCoroutine == null) {
            changingCurrentValueCoroutine = ChangingCurrentValueCoroutine();
            StartCoroutine(changingCurrentValueCoroutine);
            transform.GetComponentInChildren<CurrentValueScript>(true).BeginChangingValueDisplayed(this);
            transform.GetComponentInChildren<ArrowScript>(true).BeginMovingArrow(this);
        }

    }
    public void StopChangingCurrentValue() {
        if (changingCurrentValueCoroutine != null) {
            StopCoroutine(changingCurrentValueCoroutine);
            changingCurrentValueCoroutine = null;
            transform.GetComponentInChildren<CurrentValueScript>().StopChangingValueDisplayed();
            transform.GetComponentInChildren<ArrowScript>().StopMovingArrow();
        }
    }

    public void ToggleChangingCurrentValue() {
        if (changingCurrentValueCoroutine == null) {
            BeginChangingCurrentValue();
        } else {
            StopChangingCurrentValue();
        }
    }

    private IEnumerator ChangingCurrentValueCoroutine() {
        while (true) {
            currentValue += (int) (Time.deltaTime * speed * (maxValue - minValue));

            if (currentValue > maxValue || currentValue < minValue) {
                speed = -speed;
            }

            currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
            yield return null;
        }
    }

    public void AnimationStep() {
        GetComponent<Animator>().SetTrigger("AnimationStepTrigger");
    }

    public float getCurrentValue() {
        return currentValue;
    }

    public int getMinValue() {
        return minValue;
    }

    public int getMaxValue() {
        return maxValue;
    }
}
