using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvRemote : MonoBehaviour
{
    //public enum Channel { Friends, Jokers, Spongebob }
    //public Channel channel = Channel.Friends;

    public enum Music { TV, Lofi, Rock}
    public Music music = Music.TV;

    Vector3 tvInitPosition;
    
    Television tv;
    GameObject tvShade;

    VideoPlayer tvDisplay;
    AudioSource tvSpeakers;

    [SerializeField]
    GameObject powerButton;
    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button3;

    bool tvOn = false;

    // Start is called before the first frame update
    void Start()
    {
        tv = FindObjectOfType<Television>();
        tvDisplay = tv.GetComponent<VideoPlayer>();
        tvSpeakers = tv.GetComponent<AudioSource>();
    }

    public void ButtonPressed(string name)
    {
        if (tvDisplay == null || tvSpeakers == null)
        {
            tvDisplay = tv.GetComponent<VideoPlayer>();
            tvSpeakers = tv.GetComponent<AudioSource>();
        }
        if (name.Contains("Power"))
        {
            PowerButton();
        }
        else if (name.Contains("StopButton"))
        {
            tvDisplay.Pause();
        }
        else if (name.Contains("PauseButton"))
        {
            tvDisplay.Pause();
        }
        else if (name.Contains("PlayButton"))
        {
            if (tvOn)
            {
                tvDisplay.Play();
            }
        }
        else if (name.Contains("VolumeUp"))
        {
            tvSpeakers.volume += 0.1f;
        }
        else if (name.Contains("VolumeDown"))
        {
            tvSpeakers.volume -= 0.1f;
        }
    }

    private void PowerButton()
    {
        if (tvOn)
        {
            tv.PowerOff();
            tvOn = false;
        }
        else
        {
            tv.PowerOn();
            tvOn = true;
        }
    }
}
