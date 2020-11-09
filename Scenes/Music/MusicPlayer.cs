using System;
using Godot;

public abstract class MusicPlayer : AudioStreamPlayer
{
    static float volumeDb = 0;
    protected static void PlayStream(AudioStream stream)
    {
        AudioStreamPlayer streamPlayer = new AudioStreamPlayer();
        streamPlayer.Stream = stream;
        streamPlayer.VolumeDb = volumeDb;
        streamPlayer.Play();
    }
}
