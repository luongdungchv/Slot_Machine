using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Sirenix.OdinInspector.SerializedMonoBehaviour
{
    public static SoundController Instance;
    [SerializeField] private AudioSource persistentSource, oneShotSource;

    [SerializeField] private Dictionary<SFXEnum, AudioClip> clipMapper;

    public void PlayOneShot(SFXEnum audio){
        oneShotSource.PlayOneShot(clipMapper[audio]);
    }

    private void Awake(){
        Instance = this;
    }

}

public enum SFXEnum{
    SM_LeverPull, SM_CellStop, SM_Win
}
