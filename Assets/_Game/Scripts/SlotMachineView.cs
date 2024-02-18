using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class SlotMachineView : MonoBehaviour
{
    [SerializeField] private SlotMachine presenter;
    [SerializeField] private List<SlotMachineColumn> columnList;
    [SerializeField] private float moveLength, inertia, moveBackDuration;
    
    private List<Queue<Image>> columnQueueList;
    
    private void Start(){
        
    }
    
    public void Init(List<List<int>> initialImages){
        for(int i = 0; i < initialImages.Count; i++){
            columnList[i].SetImageSprites(initialImages[i].Select(x => presenter.GetItemSprite(x)).ToList());
        }
    }
    
    public void StartScrolling(int scrollTurn, float duration, int turnIncrement, List<List<int>> colItems){
        int i = 0;
        foreach(var col in this.columnList){  
            var colRect = col.GetComponent<RectTransform>();    
            colRect.anchoredPosition = new Vector2(colRect.anchoredPosition.x, 0);
            
            var turn = scrollTurn + 3 + i * turnIncrement;
            
            var targetPos = -moveLength * turn;
            
            var sequence = DOTween.Sequence();
            sequence.Append(colRect.DOAnchorPosY(targetPos - inertia, duration * turn).SetEase(Ease.Linear));
            sequence.Append(colRect.DOAnchorPosY(targetPos, moveBackDuration).SetEase(Ease.Linear));
            
            col.SetImageSprites(colItems[i].Select(x => presenter.GetItemSprite(x)).ToList());
            i++;
        }
    }
    public void PlayJackpotAnimation(List<ProfitResult> profitResult){
        
    }
}
