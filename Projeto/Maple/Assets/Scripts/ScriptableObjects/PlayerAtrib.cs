using UnityEngine;

[CreateAssetMenu(fileName = "Player Attributes")]
public class PlayerAtrib : ScriptableObject
{
    private float xForce = 0f;

    private float yForce = 0f;

    private bool canMove = false;

    private bool canEnd = false;

    public float XForce { get => xForce; set => xForce = value; }
    public float YForce { get => yForce; set => yForce = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanEnd { get => canEnd; set => canEnd = value; }
}
