using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderInputScript : MonoBehaviour {
    private SliderScript sliderScript;

    void Start() {
        sliderScript = GetComponent<SliderScript>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            sliderScript.ToggleChangingCurrentValue();
        }

        if (Input.GetButtonDown("Fire1")) {
            sliderScript.AnimationStep();
        }
    }
}
