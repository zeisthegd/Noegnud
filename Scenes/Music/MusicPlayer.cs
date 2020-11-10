using System;
using Godot;

public class MusicPlayer : AudioStreamPlayer
{
	static float volumeDb = AutoLoad.MusicVolume;
	public void CreateNewPlayerAndPlayStream(AudioStream stream)
	{
        AudioStreamPlayer streamPlayer = new AudioStreamPlayer();
        Global.CurrentScene.AddChild(streamPlayer);
        streamPlayer.Stream = stream;
        streamPlayer.VolumeDb = volumeDb;
        streamPlayer.Play();
	}

}
