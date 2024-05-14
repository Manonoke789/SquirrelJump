using UnityEngine;

public class SpawnParralax : MonoBehaviour
{
    [SerializeField] private GameObject [] _parralax;
    public int correntLevel;

    private void Start()
    {
        _parralax[correntLevel % _parralax.Length].SetActive(true);
    }
}
