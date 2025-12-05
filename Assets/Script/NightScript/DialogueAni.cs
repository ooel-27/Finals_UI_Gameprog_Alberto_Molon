using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueAni : MonoBehaviour
{
    public GameObject dialogueBox;

    public GameObject playerFrame;
    public TextMeshProUGUI playerText;

    public GameObject enemyFrame;
    public TextMeshProUGUI enemyText;

    public GameObject battlePanel;

    [TextArea(3, 10)]
    public string[] dialogueLines;

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (dialogueLines.Length > 0)
        {
            StartDialogue();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AdvanceDialogue();
        }
    }

    public void StartDialogue()
    {
        dialogueBox.SetActive(true);
        playerFrame.SetActive(false);
        enemyFrame.SetActive(false);

        currentLineIndex = 0;
        AdvanceDialogue();
    }

    public void AdvanceDialogue()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            isTyping = false;
            return;
        }

        if (currentLineIndex < dialogueLines.Length)
        {
            string line = dialogueLines[currentLineIndex];

            bool playerSpeaking = line.StartsWith("P:");
            bool enemySpeaking = line.StartsWith("E:");

            // Show correct frame
            playerFrame.SetActive(playerSpeaking);
            enemyFrame.SetActive(enemySpeaking);

            // Reset used text
            playerText.text = "";
            enemyText.text = "";

            string pureLine = line.Substring(2);

            if (playerSpeaking)
                typingCoroutine = StartCoroutine(TypeText(playerText, pureLine));
            else
                typingCoroutine = StartCoroutine(TypeText(enemyText, pureLine));

            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeText(TextMeshProUGUI targetText, string line)
    {
        isTyping = true;
        targetText.text = "";

        foreach (char c in line)
        {
            targetText.text += c;
            yield return new WaitForSeconds(0.04f);
        }

        isTyping = false;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        playerFrame.SetActive(false);
        enemyFrame.SetActive(false);

        // Show the battle panel
        if (battlePanel != null)
            battlePanel.SetActive(true);

        // Optionally disable the whole Dialogue system object
        // gameObject.SetActive(false);
    }

}
