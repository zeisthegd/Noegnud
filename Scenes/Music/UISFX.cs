using Godot;
using System;

public class UISFX : MusicPlayer
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
}
