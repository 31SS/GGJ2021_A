using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{

    string[] BGMFileName = new string[]
    {
        "Carousel",//タイトル
        "Kumo",//プレイ中（通常）
        "ゴシック・ナイト",//プレイ中（終盤）
        "se_maoudamashii_jingle01",//ゲームクリア（true）
        "se_maoudamashii_jingle02"//ゲームクリア（true以外）
    };

    string[] SEFileName = new string[]
    {
        "カーソル移動3",//移動
        "ドアを閉める2",//ドア開閉
        "決定、ボタン押下32",//人形合体
        "se_maoudamashii_se_fall02",//ジャンプ
        "se_maoudamashii_system37",//システム音（決定）
        "se_maoudamashii_system08"//システム音（キャンセル）
    };
    private AudioSource audio;

    void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void BGMPlay()
    {
        audio.Play();
    }

    public void BGMStop()
    {
        audio.Stop();
    }

    public void SelectBGM(string name)
    {
        int i;
        Debug.Log("BGMPlay:" + name + " length:" + BGMFileName.Length);
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        switch (name)
        {
            case "Carousel":
                i = 0;//タイトル
                break;
            case "Kumo":
                i = 1;//プレイ中（通常）
                break;
            case "ゴシック・ナイト":
                i = 2;//プレイ中（終盤）
                break;
            case "se_maoudamashii_jingle01":
                i = 3;//ゲームクリア（true）
                break;
            case "se_maoudamashii_jingle02":
                i = 4;//ゲームクリア（true以外）
                break;
            default:
                i = 0;
                break;
        }
        if (i >= BGMFileName.Length)
        {
            i = BGMFileName.Length - 1;
        }
        audio.clip = Resources.Load("Sound/BGM/" + BGMFileName[i]) as AudioClip;
        BGMPlay();
    }

    public void SEPlay(string name)
    {
        int i;
        Debug.Log("SEPlay:" + name + " length:" + SEFileName.Length);
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        switch (name)
        {
            case "カーソル移動3":
                i = 0;//移動
                break;
            case "ドアを閉める2":
                i = 1;//ドア開閉
                break;
            case "決定、ボタン押下32":
                i = 2;//人形合体
                break;
            case "se_maoudamashii_se_fall02":
                i = 3;//ジャンプ
                break;
            case "se_maoudamashii_system37":
                i = 4; //システム音（決定）
                break;
            case "se_maoudamashii_system08":
                i = 5;//システム音（キャンセル）
                break;
            default:
                i = 0;
                break;
        }
        if (i >= SEFileName.Length)
        {
            i = SEFileName.Length - 1;
        }
        Debug.Log("aa");
        AudioClip tmp;
        tmp = Resources.Load("Sound/SE/" + SEFileName[i]) as AudioClip;
        audio.PlayOneShot(tmp);
    }
}
