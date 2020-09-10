using System;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button instButton;

    private void Start() 
    {
        startGameButton.onClick.AddListener(HandleStartClicked);
        instButton.onClick.AddListener(HandleInstClicked);
    }

    private void HandleInstClicked()
    {
        GameManager.instance.LoadLevelName("Instruction");
    }

    private void HandleStartClicked()
    {
        GameManager.instance.LoadNextLevel();
    }


}
