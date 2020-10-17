using System;
using Godot;


public class Stats: Node
{
    [Export]
    private int maxHealth;//Mau toi da cua object
	private int currentHealth;//Mau hien tai cua object

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

    public int MaxHealth { 
		get => maxHealth;

		set
		{
			maxHealth = value;
			currentHealth = currentHealth < maxHealth ? currentHealth : maxHealth;
			//De current health khong lon hon maxhealth
		}
	}

    #endregion
}
