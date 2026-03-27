using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashDisplay : MonoBehaviour
{
    public TMP_Text CashUI;

    // Start is called before the first frame update
    void Start()
    {
        CashUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CashUI.text = "$" + PlayerStats.PlayerCash;
    }
}
