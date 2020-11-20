using Godot;
using System;

//Hitbox là area dùng để tấn công
//Dùng chung cho Player và Monster
public class Hitbox : Area2D
{
	[Export]
	int damage;//Damage dùng để giảm máu của các nhân vật bị tấn công
	public int Damage { get => damage; set => damage = value; }
}
