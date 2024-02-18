using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private List<Sprite> itemSpriteList;
    [SerializeField] private SlotMachineModel model;
    [SerializeField] private SlotMachineView view;
    [SerializeField] private SM_ResultHandler resultHandler;
    
    [SerializeField] private int scrollTurn, turnIncrement, row, column;
    [SerializeField] private float durationPerTurn;
    
    public int TotalItem => itemSpriteList.Count;
    public Sprite GetItemSprite(int index) => this.itemSpriteList[index];
    
    public bool IsScrolling{get; private set;}
    
    private void Start(){
        var (result, colItems) = model.GenerateResult(column, row, scrollTurn, turnIncrement);
        view.Init(colItems);
    }
    
    public void StartScrolling(){
        if(IsScrolling) return;
        
        var (result, columnItems) = model.GenerateResult(column, row, scrollTurn, turnIncrement);
        //var profitResult = resultHandler.HandleResult(result);
        
        view.StartScrolling(this.scrollTurn, this.durationPerTurn, turnIncrement, columnItems);
        
        var totalDuration = durationPerTurn * (scrollTurn + row + turnIncrement * column);
        IsScrolling = true;
        DL.Utils.CoroutineUtils.Invoke(this, () => this.IsScrolling = false, totalDuration);
    }
    
}
