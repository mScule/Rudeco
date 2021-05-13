using PoyLang;
using UnityEngine;

public class WalkSpeed : CustomCommand
{
    [SerializeField] PlayerMovement walkSpeed;

    WalkSpeed()
        : base(
            "WALKSPEED",
            new string[] {
                "Returns walkspeed of the player.",
                "First parameter sets the walkspeed."
            })
    { }

    public override string Command(string[] parameters)
    {
        if (parameters[0] == "")
            return walkSpeed.walkSpeed + "";

        else
            walkSpeed.walkSpeed = float.Parse(parameters[0]);
        return walkSpeed.walkSpeed + "";
    }
}
