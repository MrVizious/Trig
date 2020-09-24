using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxValueScript : MonoBehaviour {

    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void setValue(int newValue) {
        text.text = newValue.ToString();
    }
}
