using Godot;
using System;

public class UISFX : AudioStreamPlayer
{
	MusicPlayer musicPlayer = new MusicPlayer();
	[Export]
	AudioStream confirm;
	[Export]
	AudioStream back;

	public override void _Ready()
	{
		base._Ready();
	}

	public void PlayUIConfirm()
	{
		PlayStream(confirm);

	}

	public void PlayUIBack()
	{
		PlayStream(back);

	}
	private void PlayStream(AudioStream stream)
	{
		Stream = stream;
		VolumeDb = AutoLoad.MusicVolume;
		Play();
	}
}
