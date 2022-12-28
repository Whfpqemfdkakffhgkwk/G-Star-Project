using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public enum SoundType
{
    SFX,
    BGM,
    END
}

public class SoundManager : Singleton<SoundManager>
{
    public Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    public Dictionary<SoundType, AudioSource> audioSources = new Dictionary<SoundType, AudioSource>();
    public float[] audioVolumes = new float[(int)SoundType.END];

    public Slider audioSlider;
    public Slider sfxSlider;

    [SerializeField] private List<Button> SpecialBtns = new List<Button>();

    private bool isAudioMute = false;
    private bool isSfxMute = false;
    [SerializeField] private Sprite[] AudioSpr, SFXSpr;
    public override void Awake()
    {
        base.Awake();
        AudioClip[] clips = Resources.LoadAll<AudioClip>("SoundResources/");
        foreach (AudioClip clip in clips)
        {
            audioClips[clip.name] = clip;
        }

        string[] enumNames = System.Enum.GetNames(typeof(SoundType));
        for (int i = 0; i < (int)SoundType.END; i++)
        {
            GameObject AudioSourceObj = new GameObject(enumNames[i]); //null
            AudioSourceObj.transform.SetParent(transform);
            audioSources[(SoundType)i] = AudioSourceObj.AddComponent<AudioSource>(); //add audio
            audioVolumes[i] = 0.5f;
        }

        audioSources[SoundType.BGM].loop = true; //bgm은 루프
    }
    private void Start()
    {
        PlaySoundClip("BGM_Main", SoundType.BGM);

        foreach (Button btn in Resources.FindObjectsOfTypeAll<Button>())
        {
            if (!SpecialBtns.Contains(btn)) //SpecialBtns 리스트 안에 있는 버튼이 아니면
                btn.onClick.AddListener(() => PlaySoundClip("SFX_AnyButton", SoundType.SFX));
        }
        sliderValueaApply();
    }
    public AudioClip PlaySoundClip(string clipName, SoundType type, float volume = 0.5f, float pitch = 1)
    {
        AudioClip clip = audioClips[clipName];
        return PlaySoundClip(clip, type, volume, pitch);
    }
    public AudioClip PlaySoundClip(AudioClip clip, SoundType type, float volume = 0.5f, float pitch = 1)
    {
        audioSources[type].pitch = pitch;

        float curVolume = volume * audioVolumes[(int)type];
        if (type == SoundType.BGM)
        {
            audioSources[SoundType.BGM].clip = clip;
            audioSources[SoundType.BGM].volume = curVolume;
            audioSources[SoundType.BGM].Play();
        }
        else
        {
            audioSources[type].PlayOneShot(clip, curVolume);
        }

        return clip;
    }
    private void sliderValueaApply()
    {
        audioSlider.value = audioVolumes[0];
        sfxSlider.value = audioVolumes[1];
    }
    public void AudioSoundSetting(float index)
    {
        audioVolumes[(int)SoundType.BGM] = index;
        audioSources[SoundType.BGM].volume = index;
    }
    public void SFXSoundSetting(float index)
    {
        audioVolumes[(int)SoundType.SFX] = index;
    }
    public void AudioSoundClick()
    {
        if (!isAudioMute)
        {
            audioSources[SoundType.BGM].mute = true;
            isAudioMute = true;
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = AudioSpr[1];
        }
        else
        {
            audioSources[SoundType.BGM].mute = false;
            isAudioMute = false;
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = AudioSpr[0];
        }
    }
    public void SFXSoundClick()
    {
        if (!isSfxMute)
        {
            audioSources[(int)SoundType.SFX].mute = true;
            isSfxMute = true;
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = SFXSpr[1];
        }
        else
        {
            audioSources[((int)SoundType.SFX)].mute = false;
            isSfxMute = false;
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = SFXSpr[0];
        }
    }
}