using Godot;
using System;

public partial class Ground : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/// <summary>
	/// Reload the scene if a player has collided with the ground
	/// </summary>
	/// <param name="body"></param>
	public void OnPlayerCollided(Node2D body) {
		if (body is not Player) return;
		GetTree().CallDeferred("reload_current_scene");
	}
}
