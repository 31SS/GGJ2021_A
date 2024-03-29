﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{

    string[] BGMFileName = new string[]
    {
        "Carousel",//タイトル
        "Kumo",//プレイ中（通常）
        "ゴシック・ナイト"//プレイ中（終盤）
    };

    string[] SEFileName = new string[]
    {
        "カーソル移動3",//移動
        "ドアを閉める2",//ドア開閉
        "決定、ボタン押下32",//人形合体
        "se_maoudamashii_se_fall02",//ジャンプ
        "se_maoudamashii_system37",//システム音（決定）
        "se_maoudamashii_system08",//システム音（キャンセル）
        "se_maoudamashii_jingle01",//ゲームクリア（true）
        "se_maoudamashii_jingle02"//ゲームクリア（true以外）
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

        //シーン名に応じて
        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                SelectBGM("Carousel");
                break;
            case "mainScene":
                SelectBGM("Kumo");
                break;
            case "GameClear1":
                SEPlay("se_maoudamashii_jingle01");
                break;
            case "GameClear2":
                SEPlay("se_maoudamashii_jingle02");
                break;
            case "GameOver":
                SEPlay("se_maoudamashii_jingle02");
                break;
            default:
                break;
        }
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
            default:
                i = 0;
                break;
        }
        if (i >= BGMFileName.Length)
        {
            i = BGMFileName.Length - 1;
        }
        AudioClip tmp;
        tmp = Resources.Load("Sound/BGM/" + BGMFileName[i]) as AudioClip;
        if (!tmp)
        {
            Debug.Log("Sound/BGM/" + BGMFileName[i] + " is Missing");
        }
        else
        {
            audio.clip = tmp;
        }
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
            case "se_maoudamashii_jingle01":
                i = 6;//ゲームクリア（true）
                break;
            case "se_maoudamashii_jingle02":
                i = 7;//ゲームクリア（true以外）
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
        if (!tmp)
        {
            Debug.Log(name + " is Missing");
        }
        audio.PlayOneShot(tmp);
    }
}
