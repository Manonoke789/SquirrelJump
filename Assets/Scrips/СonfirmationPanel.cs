using UnityEngine;
using UnityEngine.UI;

public class СonfirmationPanel : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    [SerializeField] private Shop _shop;

    private void OnEnable()
    {
        _yesButton.onClick.AddListener(YesButtonDown);
        _noButton.onClick.AddListener(NoButtonDown);
    }
    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(YesButtonDown);
        _noButton.onClick.RemoveListener(NoButtonDown);
    }

    private void YesButtonDown()
    {
        _shop.Buy();
    }
    private void NoButtonDown()
    {
        gameObject.SetActive(false);
    }
}
