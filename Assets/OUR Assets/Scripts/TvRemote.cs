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

    [SerializeField]
    List<VideoClip> channels;
    int channel = 0;

    [SerializeField]
    int favIndex1;
    [SerializeField]
    int favIndex2;
    [SerializeField]
    int favIndex3;

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
        if (name.Contains("Power"))
        {
            PowerButton();
        }
        else if (name.Contains("ButtonA"))
        {
            SetChannel(favIndex1);
        }
        else if (name.Contains("ButtonB"))
        {
            SetChannel(favIndex2);
        }
        else if (name.Contains("ButtonC"))
        {
            SetChannel(favIndex3);
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
            Debug.Log("TV ON");
            tvOn = true;
            tvShade.SetActive(false);
        }
    }

    private void SetChannel(int newChannel)
    {
        channel = newChannel;
        tvDisplay.clip = channels[channel];
    }

    private void CycleChannels(bool up)
    {
        if (up && channel == channels.Count - 1)
        {
            SetChannel(0);
        }
        else if (!up && channel == 0)
        {
            SetChannel(channels.Count - 1);
        }
    }
}
