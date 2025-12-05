using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public Button FirstMap;
    public Button SecondMap;
    public Button ThirdMap;

    public GameObject panel1;
    public GameObject panel2;

    void Start()
    {
        FirstMap.onClick.AddListener(GoToPanel2);
        SecondMap.onClick.AddListener(GoToPanel2);
        ThirdMap.onClick.AddListener(GoToPanel2);
    }

    void GoToPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
