using Godot;
using System;

public class MonsterStats : Stats
{
	public override void _Ready()
	{
		base._Ready();
        Connect(nameof(MonsterStats.OutOfHealth), Global.PlayerStats, nameof(PlayerStats._on_Player_killed_Monster));
    }
	
}
