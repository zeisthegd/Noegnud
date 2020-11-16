using Godot;
using System;

public class UISFX : AudioStreamPlayer
{ 
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

	public void _on_SFX_Volume_Change()
	{
		VolumeDb = AutoLoad.SfxVolume;
	}
}
