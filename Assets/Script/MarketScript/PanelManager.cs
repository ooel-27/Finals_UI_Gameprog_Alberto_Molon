using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject staffroomPanel;
    public GameObject cashierPanel;
    public GameObject firstShelfPanel;
    public GameObject secondShelfPanel;
    public GameObject thirdShelfPanel;
    public GameObject hubPanel; // the main panel with the buttons

    [Header("Hub Buttons")]
    public Button staffroomButton;
    public Button cashierButton;
    public Button firstShelfButton;
    public Button secondShelfButton;
    public Button thirdShelfButton;

    [Header("Back Buttons")]
    public Button[] backButtons; // Assign all Back buttons in inspector

    void Start()
    {
        // Hub buttons
        staffroomButton.onClick.AddListener(() => OpenPanel(staffroomPanel));
        cashierButton.onClick.AddListener(() => OpenPanel(cashierPanel));
        firstShelfButton.onClick.AddListener(() => OpenPanel(firstShelfPanel));
        secondShelfButton.onClick.AddListener(() => OpenPanel(secondShelfPanel));
        thirdShelfButton.onClick.AddListener(() => OpenPanel(thirdShelfPanel));

        // Back buttons
        foreach (Button backBtn in backButtons)
        {
            backBtn.onClick.AddListener(() => OpenPanel(hubPanel));
        }

        // Start with hub panel active
        OpenPanel(hubPanel);
    }

    void OpenPanel(GameObject panelToOpen)
    {
        // Disable all panels first
        staffroomPanel.SetActive(false);
        cashierPanel.SetActive(false);
        firstShelfPanel.SetActive(false);
        secondShelfPanel.SetActive(false);
        thirdShelfPanel.SetActive(false);
        hubPanel.SetActive(false);

        // Enable the selected panel
        if (panelToOpen != null)
            panelToOpen.SetActive(true);
    }
}
