using Godot;
using System;
using Godot.Collections;

public partial class Player : Node3D
{
	private bool _moving;
    private const int GridSize = 2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProcessPlayerMovement();
	}

	public void ProcessPlayerMovement()
	{
		var movementSpeed = TimeSpan.FromMilliseconds(340);

		if (Input.IsActionPressed("rotate_left") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "rotation", Rotation + new Vector3(0, (MathF.PI / 2), 0), movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
			
		}
		
		if (Input.IsActionPressed("rotate_right") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "rotation", Rotation + new Vector3(0, (MathF.PI / -2), 0), movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
			
		}

		if (Input.IsActionPressed("forward") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + GetMovementAdjustedToRotation(Vector3.Forward) * GridSize, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}

		if (Input.IsActionPressed("backward") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + GetMovementAdjustedToRotation(Vector3.Back) * GridSize, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}

		if (Input.IsActionPressed("left") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position +GetMovementAdjustedToRotation(Vector3.Left) * GridSize, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}

		if (Input.IsActionPressed("right") && !_moving)
		{
			_moving = true;
			var tween = CreateTween();
			tween.TweenProperty(this, "position", Position + GetMovementAdjustedToRotation(Vector3.Right) * GridSize, movementSpeed.TotalSeconds);
			tween.TweenCallback(Callable.From(() => _moving = false));
			tween.Play();
		}
	}

	private Vector3 GetMovementAdjustedToRotation(Vector3 movement)
	{
		var rotation = Rotation.Y;
		return movement.Rotated(Vector3.Up, rotation);
	}
}
