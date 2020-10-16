using System;
using Godot;


public class Stats: Node
{
	[Export]
	protected int maxHealth;
    [Export]
    private int damage;

    private int currentHealth;
	

    public override void _Ready()
    {
        base._Ready();
		currentHealth = maxHealth;
    }



    #region Custom Signals

    [Signal]
	public delegate void OutOfHealth();

	#endregion

	#region Properties

	public int CurrentHealth
	{
		get => currentHealth;
		set
		{
			currentHealth = value;
			if (currentHealth <= 0)
				EmitSignal(nameof(OutOfHealth));
		}
	}

    protected int Damage { get => damage;}

    #endregion
}
