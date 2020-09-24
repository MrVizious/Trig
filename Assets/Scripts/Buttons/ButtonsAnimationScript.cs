using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonsAnimationScript : MonoBehaviour {

    private Dictionary<string, Transform> buttons;

    [SerializeField]
    List<string> buttonNames;

    [SerializeField]
    List<Transform> buttonTransforms;

    private void Start() {
        buttons = new Dictionary<string, Transform>();

        for (int i = 0; i < buttonNames.Count; i++) {
            buttons.Add(buttonNames[i], buttonTransforms[i]);
        }

        buttonNames.Clear();
        buttonTransforms.Clear();
    }



    void Update() {

        if (Input.GetButtonDown("X")) {
            Debug.Log("X pressed!");
            PressButton(buttons["Add"]);
        } else if (Input.GetButtonUp("X")) {
            ReleaseButton(buttons["Add"]);
        }
    }

    private void PressButton(Transform buttonToPress) {
        buttonToPress.localPosition = new Vector2(0f, -0.2f);
        buttonToPress.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.6f);
    }

    private void ReleaseButton(Transform buttonToPress) {
        buttonToPress.localPosition = new Vector2(0f, 0f);
        buttonToPress.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }


}
