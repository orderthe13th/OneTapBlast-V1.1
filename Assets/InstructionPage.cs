using UnityEngine;
using UnityEngine.UI;

public class InstructionPage : MonoBehaviour
{
    [SerializeField] private Button MenuButton;

    private void Start()
    {
        MenuButton.onClick.AddListener(HandleMenuClicked);
    }

    private void HandleMenuClicked()
    {
        GameManager.instance.StartGame();
    }
}
