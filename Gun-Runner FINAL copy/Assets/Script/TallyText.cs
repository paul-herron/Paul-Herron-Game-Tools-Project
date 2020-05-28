using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TallyText : MonoBehaviour
{
    public TextMeshProUGUI talText;
    public static int tally = 5;

    private void Start()
    {
        talText = GetComponent<TextMeshProUGUI>(); 
    }
    void Update()
    {
        
        talText.text = "SkyCars remaining: " + tally;


        if (tally == 0)
        {
            FindObjectOfType<gameManager>().WinGame();
        }
    }
}
