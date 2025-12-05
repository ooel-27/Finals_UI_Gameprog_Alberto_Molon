using UnityEngine;
using UnityEngine.UI;

public class CashierPanelManager : MonoBehaviour
{
    [Header("Main Panels")]
    public GameObject cashierPanel;          // Always visible in the background
    public GameObject customerOrderPanel;    // Overlay panel
    public GameObject calculatorPanel;       // Overlay panel

    [Header("Main Menu Buttons")]
    public Button customerOrderButton;
    public Button calculatorButton;

    [Header("Back Buttons")]
    public Button backFromCustomerOrderButton;
    public Button backFromCalculatorButton;

    void Start()
    {
        // Ensure overlay panels start hidden
        customerOrderPanel.SetActive(false);
        calculatorPanel.SetActive(false);

        // Hook up main menu buttons
        customerOrderButton.onClick.AddListener(() => ShowOverlayPanel(customerOrderPanel));
        calculatorButton.onClick.AddListener(() => ShowOverlayPanel(calculatorPanel));

        // Hook up back buttons
        backFromCustomerOrderButton.onClick.AddListener(() => HideOverlayPanel(customerOrderPanel));
        backFromCalculatorButton.onClick.AddListener(() => HideOverlayPanel(calculatorPanel));
    }

    void ShowOverlayPanel(GameObject overlayPanel)
    {
        overlayPanel.SetActive(true);
        // Optional: bring it to front
        overlayPanel.transform.SetAsLastSibling();
    }

    void HideOverlayPanel(GameObject overlayPanel)
    {
        overlayPanel.SetActive(false);
    }
}
