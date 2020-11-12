using Godot;
using System;

public class PlayerStats : Stats
{
	private int points = 0;
	private int currentExp = 0;
	private int requireExp = 6;

	[Signal]
	public delegate void ExperienceEarned();
	[Signal]
	public delegate void PointsChange();
	public override void _Ready()
	{
		base._Ready();
		Connect(nameof(ExperienceEarned), this, nameof(_on_Player_Earn_Experience));
	}



	public void _on_Player_killed_Monster()
	{
		points += 1;
		currentExp += 1;
		EmitSignal(nameof(PointsChange));
		EmitSignal(nameof(ExperienceEarned));
	}

	public void _on_Player_Earn_Experience()
	{
		if(currentExp == requireExp)
		{
			currentExp = 0;
			Damage += 1;
			EmitSignal(nameof(DamageChange));
		}
	}
   

	public int Points { get => points; set => points = value; }
}
