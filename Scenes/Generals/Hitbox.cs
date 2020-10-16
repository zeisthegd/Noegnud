using Godot;
using System;

public class Hitbox : Area2D
{
	[Export]
	int damage = 2;
	public int Damage { get => damage; set => damage = value; }
}
