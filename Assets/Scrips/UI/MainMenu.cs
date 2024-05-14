using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _endGameButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _soundButton;

    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _sound;

    private void OnEnable()
    {
        _soundButton.onClick.AddListener(Sound);
        _startGameButton.onClick.AddListener(StartGame);
        _endGameButton.onClick.AddListener(ExitGame);
        _shopButton.onClick.AddListener(OpenShop);
    }

    private void OnDisable()
    {
        _soundButton.onClick.RemoveListener(Sound);
        _startGameButton.onClick.RemoveListener(StartGame);
        _endGameButton.onClick.RemoveListener(ExitGame);
        _shopButton.onClick.RemoveListener(OpenShop);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    private void OpenShop()
    {
        _shop.SetActive(true);
    }
    private void Sound()
    {
        
    }
}
