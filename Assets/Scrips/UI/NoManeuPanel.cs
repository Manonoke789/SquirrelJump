using UnityEngine;
using UnityEngine.UI;

public class NoManeuPanel : MonoBehaviour
{
    [SerializeField] private Button _okayButton;

    private void OnEnable()
    {
        _okayButton.onClick.AddListener(OkayButtonDown);
    }
    private void OnDisable()
    {
        _okayButton.onClick.RemoveListener(OkayButtonDown);
    }

    private void OkayButtonDown()
    {
        gameObject.SetActive(false);
    }
}
