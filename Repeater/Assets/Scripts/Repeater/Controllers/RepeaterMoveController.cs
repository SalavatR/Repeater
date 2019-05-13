using Repeater.States;
using UnityEngine;

namespace Repeater.Controllers
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class RepeaterMoveController : RepeatActionControllerBase<MoveState>
    {
        [SerializeField] private ThirdPersonCharacter character;

        private void OnValidate()
        {
            character = GetComponent<ThirdPersonCharacter>();
        }

        protected override void Process(MoveState actionParameter)
        {
            character.Move(actionParameter.direction, actionParameter.isCrouch, actionParameter.isJump);
        }
    }
}