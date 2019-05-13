using UnityEngine;

namespace Repeater.States
{
    public class MoveState : IState
    {
        public float Time { get; set; }
    
        public Vector3 direction;
        public bool isCrouch;
        public bool isJump;

        public MoveState(Vector3 direction, bool isCrouch, bool isJump)
        {
            this.direction = direction;
            this.isCrouch = isCrouch;
            this.isJump = isJump;
        }
    
        public bool Ended(float objectSpawnTime)
        {
            return Time + objectSpawnTime <= UnityEngine.Time.realtimeSinceStartup;
        }

        public static bool operator !=(MoveState val1, MoveState val2)
        {
            return !(val1 == val2);
        }

        public static bool operator ==(MoveState val1, MoveState val2)
        {
            return (val1?.isJump == val2?.isJump && val1.isCrouch == val2.isCrouch
                                                 && val1.direction == val2.direction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is MoveState)) return false;

            return this == (MoveState) obj;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = direction.GetHashCode();
                hashCode = (hashCode * 397) ^ isCrouch.GetHashCode();
                hashCode = (hashCode * 397) ^ isJump.GetHashCode();
                hashCode = (hashCode * 397) ^ Time.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{direction} {isJump} {isCrouch} {Time}";
        }
    }
}