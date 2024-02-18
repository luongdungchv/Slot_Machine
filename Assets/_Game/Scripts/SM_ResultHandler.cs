using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_ResultHandler : MonoBehaviour
{
    //(profit multiplier, list of prize item)
    public List<ProfitResult> HandleResult(List<List<int>> result){
        var res = new List<ProfitResult>();
        
        var firstLineResult = TryHandleFirstLine(result);
        var midLineResult = TryHandleMidLine(result);
        var bottomLineResult = TryHandleBottomLine(result);
        var pyramidResultt = TryHandlePyramid(result);
        var reversePyramidResult = TryHandleReversePyramid(result);
        
        res.Add(firstLineResult);
        res.Add(midLineResult);
        res.Add(bottomLineResult);
        res.Add(pyramidResultt);
        res.Add(reversePyramidResult);
        
        return res;
    }
    private ProfitResult TryHandleFirstLine(List<List<int>> result){
        int item = result[0][0];
        var list = new List<(int, int)>();
        
        int index = 0;
        foreach(var col in result){
            list.Add((index, 0));
            if(col[0] != item){
                return new ProfitResult();
            }
            index++;
        }
        
        return new ProfitResult(){
            multiplier = 1.2f,
            itemCoordinates = list
        };
    }
    private ProfitResult TryHandleBottomLine(List<List<int>> result){
        int item = result[0][1];
        var list = new List<(int, int)>();
        
        int index = 0;
        foreach(var col in result){
            list.Add((index, 1));
            if(col[1] != item){
                return new ProfitResult();
            }
            index++;
        }
        
        return new ProfitResult(){
            multiplier = 1.2f,
            itemCoordinates = list
        };
    }
    private ProfitResult TryHandleMidLine(List<List<int>> result){
        int item = result[0][2];
        var list = new List<(int, int)>();
        
        int index = 0;
        foreach(var col in result){
            list.Add((index, 2));
            if(col[2] != item){
                return new ProfitResult();
            }
            index++;
        }
        
        return new ProfitResult(){
            multiplier = 2,
            itemCoordinates = list
        };
    }
    private ProfitResult TryHandlePyramid(List<List<int>> result){
        var list = new List<int>();
        list.Add(result[0][2]);
        list.Add(result[1][1]);
        list.Add(result[2][0]);
        list.Add(result[3][1]);
        list.Add(result[4][2]);
        foreach(var i in list) if(i != list[0]) return new ProfitResult();
        return new ProfitResult(){
            multiplier = 1.2f, 
            itemCoordinates = new List<(int, int)>(){(0, 2), (1,1), (2,0), (3,1), (4,2)}
        };
    }
    private ProfitResult TryHandleReversePyramid(List<List<int>> result){
        var list = new List<int>();
        list.Add(result[0][0]);
        list.Add(result[1][1]);
        list.Add(result[2][2]);
        list.Add(result[3][1]);
        list.Add(result[4][0]);
        foreach(var i in list) if(i != list[0]) return new ProfitResult();
        return new ProfitResult{
            multiplier = 1.2f, 
            itemCoordinates = new List<(int, int)>(){(0,0), (1,1), (2,2), (3,1), (4,0)}
        };
    }
}

public class ProfitResult{
    public float multiplier;
    public List<(int, int)> itemCoordinates;
}

