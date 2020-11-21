using Godot;
using System;

public class Fireball : KinematicBody2D
{
	[Export]
	PackedScene hitEffect;
	KinematicBody2D target;
	public override void _Ready()
	{
		
	}
	
	private void _on_Hitbox_body_entered(object body)
	{
		Node2D hitFX = (Node2D)hitEffect.Instance();
		var currentScene = GetTree().CurrentScene;
		currentScene.GetNode("MainSort").AddChild(hitFX);
		hitFX.GlobalPosition = this.GlobalPosition;
		QueueFree();
	}

	public void SetTarget(KinematicBody2D target)
    {
		this.target = target;
    }
}



