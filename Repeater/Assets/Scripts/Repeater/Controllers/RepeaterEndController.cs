using Repeater.States;

namespace Repeater.Controllers
{
    public class RepeaterEndController : RepeatActionControllerBase<EndState>
    {
        protected override void Process(EndState actionParameter)
        {
            if (actionParameter.NeedDestroyGameObject)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}