using Godot;
using System;

public class Monster : KinematicBody2D
{
	Area2D hurtBox;
	public override void _Ready()
	{
		hurtBox = (Area2D)GetNode("Hurtbox");
	}
	public void _on_Hurtbox_area_entered(Area2D area)
	{
		QueueFree();
	}

}

