using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineColumn : MonoBehaviour
{
    [SerializeField] private List<Image> itemImages; 
    
    public void SetImageSprites(List<Sprite> spriteList){
        for(int i = 0; i < spriteList.Count; i++){
            Debug.Log(spriteList[i]);
            itemImages[i].sprite = spriteList[i];
        }
    }
}
