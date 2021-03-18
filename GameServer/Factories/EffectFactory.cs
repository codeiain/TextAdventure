using System;
using System.Collections.Generic;
using GameServer.Effects;
using GameServer.Models;

namespace GameServer.Factories
{
    public class EffectFactory
    {
        Dictionary<Type, string> _typeDict = new Dictionary<Type, string>
        {
            {typeof(AddStatus),"addStatus"},
            {typeof(RemoveStatus),"removeStatus"},
            {typeof(StatusUpdate),"statusUpdate"}
        };
        public static IStatus GetEffect(Effect effect)
        {
            if (effect?.AddStatus == "" && effect?.Target == "") return new AddStatus(effect);
            if (effect?.RemoveStatus == "" && effect?.Target == "") return new RemoveStatus();
            if (effect?.StatusUpdate == "" && effect?.Target == "") return new StatusUpdate();

            return null;
        }
    }
}