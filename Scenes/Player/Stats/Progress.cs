using Godot;
using System;

public class Progress : TextureRect
{
	Label damage;
	Label points;
	TextureProgress experience;

	public override void _Ready()
	{
		damage = (Label)GetNode("Damage");
		points = (Label)GetNode("Points");
		experience = (TextureProgress)GetNode("Experience");
		experience.Value = 0;

		damage.Text = Global.PlayerStats.Damage.ToString();
		points.Text = Global.PlayerStats.Points.ToString();

		Global.PlayerStats.Connect(nameof(PlayerStats.PointsChange), this, nameof(_on_Player_points_changed));
		Global.PlayerStats.Connect(nameof(PlayerStats.DamageChange), this, nameof(_on_Player_damage_changed));


	}

	public void _on_Player_points_changed()
	{
		points.Text = Global.PlayerStats.Points.ToString();
		experience.Value += 1;
	}
	public void _on_Player_damage_changed()
	{
		experience.Value = 0;
		damage.Text = Global.PlayerStats.Damage.ToString();
	}
}
