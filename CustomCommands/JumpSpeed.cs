using UnityEngine;
using PoyLang;

class JumpSpeed : CustomCommand
{
    [SerializeField] PlayerMovement jumpSpeed;

    public JumpSpeed()
        : base(
            "JUMPSPEED",
            new string[]
            {
                "Returns jumpspeed of the player.",
                "First parameter sets the jumpspeed."
            })
    { }

    public override string Command(string[] parameters)
    {
        if (parameters[0] != "")
            jumpSpeed.jumpSpeed = float.Parse(parameters[0]);

        return jumpSpeed.jumpSpeed + "";
    }
}
