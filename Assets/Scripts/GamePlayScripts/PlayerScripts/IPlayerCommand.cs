using UnityEngine;

namespace Player.Command
{
    public interface IPlayerCommand
    {
        void ButtonDown(GameObject gameobject);
        void ButtonHold(GameObject gameobject);
        void ButtonUp(GameObject gameobject);
    }
}
