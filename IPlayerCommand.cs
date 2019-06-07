using UnityEngine;

namespace Player.Command
{
    public interface IPlayerCommand
    {
        void Execute(GameObject gameobject);
    }
}
