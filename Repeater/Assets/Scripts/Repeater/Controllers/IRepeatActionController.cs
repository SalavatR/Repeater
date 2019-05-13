using System;


//Добавлен для поиска, через компоненты, или рефлексиюs
namespace Repeater.Controllers
{
    public interface IRepeatActionController
    {
        Type ControllerType { get; }
        void Process(object actionParameter);
    }
}