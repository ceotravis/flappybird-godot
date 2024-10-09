using Godot;
using System;

public partial class Pillar : StaticBody2D {
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	Vector2 speed = new Vector2(200, 0);
	public override void _Process(double delta) {
		Position -= speed * (float)delta;
	}

    /// <summary>
	/// Reload the scene if the player collides with a pillar
	/// </summary>
	/// <param name="body">The body that collied with the pillar</param>
	public void OnPlayerCollided(Node2D body) {
		if (body is not Player) return;

		GetTree().CallDeferred("reload_current_scene");
	}

	/// <summary>
	/// Remove the pillar if is not visible on the screen
	/// </summary>
	public void ScreenExited() {
		QueueFree();
	}
}
