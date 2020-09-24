using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B83.ExpressionParser;


public class CalculatorScript : MonoBehaviour {

    [SerializeField]
    private string input;

    ExpressionParser parser;

    void Start() {
        parser = new ExpressionParser();
    }

    public void ChangeInput(string newInput) {
        input = newInput;
    }

    public float Calculate() {
        Expression expression = parser.EvaluateExpression(input);
        Debug.Log(input + "=" + expression.Value);
        return (float)expression.Value;
    }

}
