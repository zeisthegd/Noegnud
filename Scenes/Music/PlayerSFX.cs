using Godot;
using System;

public class PlayerSFX : MusicPlayer
{
	[Export]
	static AudioStream hurt;
	[Export]
	static AudioStream swipe;
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


}
