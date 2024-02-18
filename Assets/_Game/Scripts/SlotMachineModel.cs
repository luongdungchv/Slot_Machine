using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DL.Utils;

public class SlotMachineModel : Sirenix.OdinInspector.SerializedMonoBehaviour
{
    [SerializeField] private SlotMachine presenter;

    //Result of each column 
    [SerializeField] private List<List<int>> currentResult, currentColItems;

    public (List<List<int>>, List<List<int>>) GenerateResult(int column, int row, int scrollTurn, int turnIncrement, List<List<int>> forceResult = null)
    {
        var result = new List<List<int>>();
        var columnItemList = new List<List<int>>();

        for (int i = 0; i < column; i++)
        {
            var itemIndexList = new List<int>();
            for (int j = 0; j < presenter.TotalItem; j++)
                itemIndexList.Add(j);

            itemIndexList = itemIndexList.ShuffleCollection();
            var resultItems = new List<int>();

            if (forceResult == null)
                for (int j = 0; j < row; j++)
                    resultItems.Add(itemIndexList[j]);
            else resultItems = forceResult[i];

            result.Add(resultItems);

            var columnItems = new List<int>();
            if (currentResult != null) currentResult[i].ForEach(x => columnItems.Add(x));
            else
                resultItems.ForEach(x => columnItems.Add(x));
            for (int j = 0; j < scrollTurn + i * turnIncrement; j++)
            {
                columnItems.Add(Random.Range(0, presenter.TotalItem));
            }
            columnItems.AddRange(resultItems);
            columnItemList.Add(columnItems);
        }

        this.currentResult = result;
        this.currentColItems = columnItemList;

        return (result, columnItemList);
    }
}
