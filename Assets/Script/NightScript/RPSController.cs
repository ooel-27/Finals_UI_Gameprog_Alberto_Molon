using UnityEngine;
using UnityEngine.UI;

public class RPSController : MonoBehaviour
{
    public Button rockButton;
    public Button paperButton;
    public Button scissorButton;

    public Image playerImage;
    public Image enemyImage;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorSprite;

    public Image[] playerHearts; // 3 hearts
    public Image[] enemyHearts;  // 3 hearts

    public GameObject gameOverPanel;
    public GameObject wonPanel;

    public GameObject battlePanel;

    private Sprite[] choices;

    private int playerLives = 3;
    private int enemyLives = 3;

    public MarketBoxManager marketBoxManager;


    void Start()
    {
        choices = new Sprite[] { rockSprite, paperSprite, scissorSprite };

        rockButton.onClick.AddListener(() => PlayerChoose(rockSprite, 0));
        paperButton.onClick.AddListener(() => PlayerChoose(paperSprite, 1));
        scissorButton.onClick.AddListener(() => PlayerChoose(scissorSprite, 2));
    }

    void PlayerChoose(Sprite playerChoice, int playerIndex)
    {
        // Display player's selection
        playerImage.sprite = playerChoice;

        // Enemy selection
        int enemyIndex = Random.Range(0, choices.Length);
        Sprite enemyChoice = choices[enemyIndex];
        enemyImage.sprite = enemyChoice;

        // Determine outcome
        EvaluateRound(playerIndex, enemyIndex);
    }

    void EvaluateRound(int player, int enemy)
    {
        if (player == enemy)
        {
            Debug.Log("DRAW");
            return;
        }

        // Win/Lose logic:
        // 0 = Rock, 1 = Paper, 2 = Scissors
        bool playerWins =
            (player == 0 && enemy == 2) ||
            (player == 1 && enemy == 0) ||
            (player == 2 && enemy == 1);

        if (playerWins)
        {
            enemyLives--;
            UpdateHearts(enemyHearts, enemyLives);
            Debug.Log("Player Wins Round!");
        }
        else
        {
            playerLives--;
            UpdateHearts(playerHearts, playerLives);
            Debug.Log("Enemy Wins Round!");
        }

        CheckGameOver();
    }

    void UpdateHearts(Image[] hearts, int livesLeft)
    {
        // Turn off the hearts visually
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < livesLeft;
        }
    }

    void CheckGameOver()
    {
        if (playerLives <= 0)
        {
            Debug.Log("PLAYER LOSES THE MATCH!");

            DisableButtons();

            // hide battle panel
            if (battlePanel != null)
                battlePanel.SetActive(false);

            // show Game Over UI
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }

        if (enemyLives <= 0)
        {
            Debug.Log("PLAYER WINS THE MATCH!");

            DisableButtons();

            if (battlePanel != null)
                battlePanel.SetActive(false);

            // ⭐ Correct instance call
            if (marketBoxManager != null)
                marketBoxManager.RestockAll();

            if (wonPanel != null)
                wonPanel.SetActive(true);
        }


    }

    void DisableButtons()
    {
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorButton.interactable = false;
    }
}
