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
            RandomizeMaxAndMinValues();
        } else if (a > b) {
            maxValue = a;
            minValue = b;
        } else {
            maxValue = b;
            maxValue = a;
        }
    }

    public void RandomizeSpeed() {
        speed = Random.Range(-MAX_SPEED, MAX_SPEED);
    }

    public void BeginChangingCurrentValue() {
        if (changingCurrentValueCoroutine == null) {
            changingCurrentValueCoroutine = ChangingCurrentValueCoroutine();
            StartCoroutine(changingCurrentValueCoroutine);
        }
    }
    public void StopChangingCurrentValue() {
        if (changingCurrentValueCoroutine != null) {
            StopCoroutine(changingCurrentValueCoroutine);
            changingCurrentValueCoroutine = null;
        }
    }

    private IEnumerator ChangingCurrentValueCoroutine() {
        while (true) {
            currentValue = (int) (currentValue + (Time.deltaTime * speed * (maxValue - minValue)));

            if (currentValue > maxValue || currentValue < minValue) {
                speed = -speed;
            }

            currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
            yield return null;
        }
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
