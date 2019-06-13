using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField]
    AudioClip[] BGMClips;
    [SerializeField]
    AudioClip[] SEClips;

    private AudioSource bgmSource;
    private AudioSource seSource;

    //音量設定用変数
    private List<float> bgmVolums = new List<float>();

    // Use this for initialization
    void Awake () {
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.playOnAwake = true;
        bgmSource.loop = true;

        seSource = gameObject.AddComponent<AudioSource>();
        seSource.playOnAwake = false;
        seSource.loop = false;

        //BGMの数だけ音量設定用変数を作成
        for(int i=0;i<BGMClips.Length;i++)
        {
            bgmVolums.Add(1.0f);
        }

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySE(int number)
    {
        seSource.PlayOneShot(SEClips[number]);
    }

    public void PlayBGM(int number)
    {
        bgmSource.volume = bgmVolums[number];//音量設定
        bgmSource.Stop();
        bgmSource.clip = BGMClips[number];
     //   bgmSource.Play();
    }
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public bool IsBGMPlaying()
    {
        return bgmSource.isPlaying; 
    }

    public void SetBGMVolume(int num , float vol)
    {
        bgmVolums[num] = vol;
    }
}
