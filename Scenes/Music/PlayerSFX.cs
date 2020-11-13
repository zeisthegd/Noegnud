using Godot;
using System;

public class PlayerSFX : AudioStreamPlayer
{
	MusicPlayer musicPlayer = new MusicPlayer();
	[Export]
	AudioStream hurt;
	[Export]
	AudioStream swipe;
	public override void _Ready()
	{
		base._Ready();
	}
	public void PlayHurtSFX()
	{
		PlayStream(hurt);
	}

	public void PlaySwipeSFX()
	{
		PlayStream(swipe);
	}

	private void PlayStream(AudioStream stream)
	{
		Stream = stream;
		VolumeDb = AutoLoad.MusicVolume;
		Play();
	}


}
