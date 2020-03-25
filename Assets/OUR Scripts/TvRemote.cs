using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvRemote : MonoBehaviour
{
    public enum Channel { Friends, Jokers, Spongebob }
    public Channel channel = Channel.Friends;

    public enum Music { TV, Lofi, Rock}
    public Music music = Music.TV;

    Vector3 tvInitPosition;

    [SerializeField]
    GameObject tvScreen;
    [SerializeField]
    GameObject tvShade;
    VideoPlayer tvDisplay;
    AudioSource tvSpeakers;

    [SerializeField]
    GameObject powerButton;
    [SerializeField]
    GameObject buttonA;
    [SerializeField]
    GameObject buttonB;
    [SerializeField]
    GameObject buttonC;
    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;
    [SerializeField]
    GameObject button3;
    [SerializeField]
    GameObject channelUp;
    [SerializeField]
    GameObject channelDown;
    [SerializeField]
    GameObject volumeUp;
    [SerializeField]
    GameObject volumeDown;

    bool tvOn = false;

    // Start is called before the first frame update
    void Start()
    {
        tvDisplay = tvScreen.GetComponent<VideoPlayer>();
        tvSpeakers = tvScreen.GetComponent<AudioSource>();
    }
    

    public void ButtonPressed(string name)
    {
        if (tvDisplay == null || tvSpeakers == null)
        {
            tvDisplay = tvScreen.GetComponent<VideoPlayer>();
            tvSpeakers = tvScreen.GetComponent<AudioSource>();
        }
        Debug.Log(name);
        if (name.Contains("Power"))
        {
            PowerButton();
        }
        else if (name.Contains("ButtonA"))
        {
            SetChannel(Channel.Friends);
        }
        else if (name.Contains("ButtonB"))
        {
            SetChannel(Channel.Jokers);
        }
        else if (name.Contains("ButtonC"))
        {
            SetChannel(Channel.Spongebob);
        }
        else if (name.Contains("StopButton"))
        {
            tvDisplay.Stop();
        }
        else if (name.Contains("PauseButton"))
        {
            tvDisplay.Pause();
        }
        else if (name.Contains("PlayButton"))
        {
            if (tvDisplay.isPlaying)
            {
                tvDisplay.Pause();
            }
            else
            {
                tvDisplay.Play();
            }
        }
        else if (name.Contains("ChannelUp"))
        {
            CycleChannels(true);
        }
        else if (name.Contains("ChannelDown"))
        {
            CycleChannels(false);
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
            tvOn = false;
            tvDisplay.Pause();
            tvShade.SetActive(true);
        }
        else
        {
            tvOn = true;
            tvDisplay.Play();
            tvShade.SetActive(false);
        }
    }

    private void SetChannel(Channel newChannel)
    {
        channel = newChannel;
        switch (newChannel)
        {
            case Channel.Friends:
                tvDisplay.url = "https://drive.google.com/uc?export=download&id=1VIgLgK0Btms4Pg6fC8KnORDTnEINNjoc";
                break;
            case Channel.Jokers:
                tvDisplay.url = "https://drive.google.com/uc?export=download&id=1RyhfeCx4S4REtBPffX3IApj6dy9BiMsx";
                break;
            case Channel.Spongebob:
                tvDisplay.url = "https://drive.google.com/uc?export=download&id=1SeE6ZHRoLPA0FqG6gAliHmkLZsiQhJuX";
                break;
        }
    }

    private void CycleChannels(bool up)
    {
        if ((up && channel == Channel.Spongebob) || !up && channel == Channel.Friends)
        {
            SetChannel(Channel.Jokers);
        }
        else if ((up && channel == Channel.Friends) || !up && channel == Channel.Jokers)
        {
            SetChannel(Channel.Spongebob);
        }
        else if ((up && channel == Channel.Jokers) || !up && channel == Channel.Spongebob)
        {
            SetChannel(Channel.Friends);
        }
    }
}
