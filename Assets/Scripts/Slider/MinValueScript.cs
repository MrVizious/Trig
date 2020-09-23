using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinValueScript : MonoBehaviour {

    private Text text;

    void Start() {
        text = GetComponent<Text>();
    }

    public void setValue(int newValue) {
        text.text = newValue.ToString();
    }
}
