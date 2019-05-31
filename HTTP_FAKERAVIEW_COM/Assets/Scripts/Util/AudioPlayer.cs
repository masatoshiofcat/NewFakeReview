using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField]
    int playSENumOnAwake = -1;

    [SerializeField]
    int playBGMBumOnAwake = -1;



    private void Start()
    {
        this.PlayBGM(this.playBGMBumOnAwake);
        this.PlaySE(this.playSENumOnAwake);
    }

    public void PlayBGM(int num)
    {
        if (num < 0) return;
        AudioManager.Instance.PlayBGM(num);
    }

    /// <summary>
    /// 効果音を再生
    /// </summary>
    /// <param name="num"></param>
    public void PlaySE(int num)
    {
        if (num < 0) return;
        AudioManager.Instance.PlaySE(num);
    }
}
