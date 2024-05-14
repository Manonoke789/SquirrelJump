using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class InGameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _levelBar;

    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;
    [SerializeField] private Image _image3;
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpawnParralax _spawnParralax;

    [SerializeField] private Button _pausseButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartLevelButton2;
    [SerializeField] private Button _restartLevelButton3;
    [SerializeField] private Button _mainMenuButton2;

    [SerializeField] private GameObject _paussMenu;
    [SerializeField] private GameObject _nextLevel;
    [SerializeField] private GameObject _stars1;
    [SerializeField] private GameObject _stars2;
    [SerializeField] private GameObject _stars3;
    private SaveData _saveData;

    private void Awake()
    {
        _saveData = SavesService.Instance.Load<SaveData>();


        _playerController.Level = _saveData.Level;
        _gold.text = _saveData.Gold.ToString();
        _spawnParralax.correntLevel = _saveData.Level;
    }
    private void Start()
    {
        _slider.maxValue = UnityEngine.Random.Range(30, 50);
        _levelBar.text = Convert.ToString(_playerController.Level + 1); 
    }
    private void Update()
    {
        _slider.value += Time.deltaTime;
        if(_slider.value == _slider.maxValue)
        {
            Time.timeScale = 0;
            _nextLevel.SetActive(true);
            if(_playerController.numberOfLives == 1)
                _stars1.SetActive(true);
            else if (_playerController.numberOfLives == 2)
                _stars2.SetActive(true);
            else if (_playerController.numberOfLives == 3)
                _stars3.SetActive(true);
        }
    }


    public void HealchBarController(int lives)
    {
        if (lives == 2)
        {
            _image3.color = Color.black;
        }
        else if (lives == 1)
        {
            _image2.color = Color.black;
        }
        else if (lives == 0)
        {
            _image1.color = Color.black;
        }
    }
    public void CointBar()
    {
        _saveData.Gold += 1;
        _gold.text = _saveData.Gold.ToString();

    }

    private void OnEnable()
    {
        _pausseButton.onClick.AddListener(PausseMenu);
        _continueButton.onClick.AddListener(ContinueGame);
        _restartLevelButton.onClick.AddListener(RestartLevel);
        _mainMenuButton.onClick.AddListener(MainMenu);
        _mainMenuButton2.onClick.AddListener(MainMenu);
        _restartLevelButton2.onClick.AddListener(RestartLevel);
        _restartLevelButton3.onClick.AddListener(RestartLevel);
        _nextLevelButton.onClick.AddListener(NextLevel);
    }
    private void OnDisable()
    {
        _pausseButton.onClick.RemoveListener(PausseMenu);
        _continueButton.onClick.RemoveListener(ContinueGame);
        _restartLevelButton.onClick.RemoveListener(RestartLevel);
        _mainMenuButton.onClick.RemoveListener(MainMenu);
        _mainMenuButton2.onClick.RemoveListener(MainMenu);
        _restartLevelButton2.onClick.RemoveListener(RestartLevel);
        _restartLevelButton3.onClick.RemoveListener(RestartLevel);
        _nextLevelButton.onClick.RemoveListener(NextLevel);
    }
    private void PausseMenu()
    {
        _paussMenu.SetActive(true);
        Time.timeScale = 0;
    }
    private void ContinueGame()
    {
        _paussMenu.SetActive(false);
        Time.timeScale = 1;
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void NextLevel()
    {
        _saveData.Level += 1;
        SavesService.Instance.Save(_saveData);
        SceneManager.LoadScene(1);
    }
}
