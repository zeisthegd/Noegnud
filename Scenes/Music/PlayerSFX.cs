using Godot;
using System;

public class PlayerSFX : AudioStreamPlayer
{
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

	public void _on_SFX_Volume_Change()
	{
		VolumeDb = AutoLoad.SfxVolume;
	}

}
