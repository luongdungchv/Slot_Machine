using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions.CasualGame;

public class SlotMachineColumn : MonoBehaviour
{
    [SerializeField] private List<Image> itemImages;
    [SerializeField] private Queue<ParticleSystem> fxQueue;
    [SerializeField] private ParticleSystem fxPrefab;
    [SerializeField] private float fxDuration;

    private void Start()
    {
        fxQueue = new Queue<ParticleSystem>();
        for (int i = 0; i < 3; i++)
        {
            var fx = Instantiate(fxPrefab);
            fx.transform.SetParent(this.transform);
            fx.gameObject.SetActive(false);
            fxQueue.Enqueue(fx);
        }
        
    } 
    
    public void SetImageSprites(List<Sprite> spriteList){
        for(int i = 0; i < spriteList.Count; i++){
            itemImages[i].sprite = spriteList[i];
        }
    }
    public void PlayItemAnimation(int index){
        Debug.Log(index);
        var fx = fxQueue.Dequeue();
        fxQueue.Enqueue(fx);
        fx.GetComponent<RectTransform>().anchoredPosition = itemImages[index].GetComponent<RectTransform>().anchoredPosition;
        fx.gameObject.SetActive(true);
        fx.GetComponent<UIParticleSystem>().StartParticleEmission();
        DL.Utils.CoroutineUtils.Invoke(this, () => fx.gameObject.SetActive(false), fxDuration);
    }
    [Sirenix.OdinInspector.Button]
    private void Test(){
        var fx = fxQueue.Dequeue();
        fxQueue.Enqueue(fx);
        fx.Play();
    }
}
