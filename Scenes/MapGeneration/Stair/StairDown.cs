using Godot;
using System;

public class StairDown : Area2D
{
	public override void _Ready()
	{
		
	}

	[Signal]
	public delegate void PlayerReachedExit();

	private void _on_StairDown_body_entered(object body)
	{
		if(body is Player player)
		{
			GD.Print("Player reached exit");
			AutoLoad.Global.ReloadScene(Global.CurrentScene);			
		}
	}
}



