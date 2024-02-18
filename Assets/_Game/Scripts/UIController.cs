using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button auto, maxBet, addBet, minusBet;
    [SerializeField] private TMP_Text textBalance, textWin, textBet;

    public int CurrentBet => int.Parse(textBet.text);
    public int CurrentWin => int.Parse(textWin.text);
    public int CurrentBalance => int.Parse(textBalance.text);

    private void Awake(){
        auto.onClick.AddListener(this.Auto);
        maxBet.onClick.AddListener(this.MaxBet);
        addBet.onClick.AddListener(this.AddBet);
        minusBet.onClick.AddListener(this.MinusBet);
        Application.targetFrameRate = 60;
    }

    private void Start(){
        textBalance.text = PlayerPrefs.GetInt("Balance", 10000).ToString();
        textWin.text = "0";
        textBet.text = "2000";
    }

    public void HandleWinResult(float multiplier){
        this.textWin.text = (CurrentBet * multiplier).ToString();
        textBalance.text = (CurrentBalance + CurrentWin).ToString();
        PlayerPrefs.SetInt("Balance", CurrentBalance);
    }

    private void AddBet(){
        textBet.text = (CurrentBet + 10000).ToString();
    }
    private void MinusBet(){
        var bet = CurrentBet - 1000;
        if(bet < 0) bet = 0;
        textBet.text = bet.ToString();

    }
    private void Auto(){

    }
    private void MaxBet(){
        this.textBet.text = this.textBalance.text;
    }
    [Sirenix.OdinInspector.Button]
    public void AddBalance(int amount){
        this.textBalance.text = (CurrentBalance + amount).ToString();
    }
    [Sirenix.OdinInspector.Button]
    public void ReduceBalance(int amount){
        this.textBalance.text = (CurrentBalance - amount).ToString();
    }
    public void ReduceBalanceWithBet(){
        this.ReduceBalance(CurrentBet);
    }
}
