using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text numberShower;

    [Header("Number Buttons (0-9)")]
    public Button[] numberButtons; // Assign 0 to 9 buttons in order

    [Header("Operator Buttons")]
    public Button addButton;
    public Button subtractButton;
    public Button multiplyButton;
    public Button divideButton;
    public Button equalButton;
    public Button clearButton;

    private string currentInput = "";
    private float lastValue = 0;
    private string currentOperator = "";
    private bool operatorJustPressed = false;

    void Start()
    {
        if (numberShower != null)
            numberShower.text = "0";

        // Hook up number buttons
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int index = i; // local copy for closure
            if (numberButtons[index] != null)
                numberButtons[index].onClick.AddListener(() => OnNumberButtonPressed(index.ToString()));
        }

        // Hook up operator buttons
        if (addButton != null)
            addButton.onClick.AddListener(() => OnOperatorButtonPressed("+"));
        if (subtractButton != null)
            subtractButton.onClick.AddListener(() => OnOperatorButtonPressed("-"));
        if (multiplyButton != null)
            multiplyButton.onClick.AddListener(() => OnOperatorButtonPressed("X"));
        if (divideButton != null)
            divideButton.onClick.AddListener(() => OnOperatorButtonPressed("%"));
        if (equalButton != null)
            equalButton.onClick.AddListener(OnEqualButtonPressed);
        if (clearButton != null)
            clearButton.onClick.AddListener(OnClearButtonPressed);
    }

    public void OnNumberButtonPressed(string number)
    {
        if (operatorJustPressed)
        {
            currentInput = "";
            operatorJustPressed = false;
        }

        if (currentInput == "0" && number == "0") return;

        if (currentInput == "0")
            currentInput = number;
        else
            currentInput += number;

        UpdateDisplay();
    }

    public void OnOperatorButtonPressed(string op)
    {
        if (currentInput == "")
            return;

        if (currentOperator != "")
        {
            CalculateResult();
        }
        else
        {
            float.TryParse(currentInput, out lastValue);
        }

        currentOperator = op;
        operatorJustPressed = true;
    }

    public void OnEqualButtonPressed()
    {
        if (currentOperator != "" && currentInput != "")
        {
            CalculateResult();
            currentOperator = "";
        }
    }

    public void OnClearButtonPressed()
    {
        currentInput = "";
        lastValue = 0;
        currentOperator = "";
        UpdateDisplay("0");
    }

    private void CalculateResult()
    {
        if (!float.TryParse(currentInput, out float currentValue))
        {
            Debug.LogError("Invalid number input");
            return;
        }

        float result = lastValue;

        switch (currentOperator)
        {
            case "+":
                result = lastValue + currentValue;
                break;
            case "-":
                result = lastValue - currentValue;
                break;
            case "X":
            case "*":
                result = lastValue * currentValue;
                break;
            case "/":
                if (currentValue != 0)
                    result = lastValue / currentValue;
                else
                {
                    Debug.LogError("Division by zero");
                    return;
                }
                break;
            default:
                Debug.LogWarning("Unknown operator " + currentOperator);
                break;
        }


        currentInput = result.ToString();
        lastValue = result;
        UpdateDisplay();
        operatorJustPressed = true;
    }

    private void UpdateDisplay(string text = null)
    {
        if (numberShower != null)
        {
            numberShower.text = text ?? currentInput;
        }
    }
}
