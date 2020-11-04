using Godot;
using System;

public class StartMenu : Control
{
	//AudioStream loginScreen = (AudioStream)ResourceLoader.Load(@"res://Audio/Music/Home - Toby Fox.ogg");
	Global global;
	public override void _Ready()
	{
		//AutoLoad.PlayMusic(this,loginScreen);
	}


	private void _on_Start_pressed()
	{
		AutoLoad.Global.GotoScene(Global.Game);
	}

	
	private void _on_Ranking_pressed()
	{
		AutoLoad.Global.GotoScene(Global.Ranking);
	}


	private void _on_Options_pressed()
	{
		AutoLoad.Global.GotoScene(Global.Option);
	}

	private void _on_Exit_pressed()
	{
		GetTree().Quit();
	}
	private void _on_Logout_pressed()
	{
		AutoLoad.Global.GotoScene(Global.LoginScreen);
	}

}












