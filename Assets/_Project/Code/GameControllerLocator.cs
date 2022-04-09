using System;
using System.Collections.Generic;

namespace GraveKiller
{
    public class GameControllerLocator
    {
        private static GameControllerLocator instance;

        public static GameControllerLocator GetInstance()
        {
            return instance ??= new GameControllerLocator();
        }

        private readonly Dictionary<Type, object> controllerDictionary;

        private GameControllerLocator()
        {
            this.controllerDictionary = new Dictionary<Type, object>();
        }
        
        public void RegisterController<T>(T controller)
        {
            Type type = typeof(T);
            this.controllerDictionary.Add(type, controller);
        }

        public T GetController<T>()
        {
            Type type = typeof(T);

            return (T) this.controllerDictionary[type];
        }

        public void UnRegisterController<T>()
        {
            Type type = typeof(T);
            this.controllerDictionary.Remove(type);
        }
        
        public void Clear()
        {
            this.controllerDictionary.Clear();
        }
    }
}
