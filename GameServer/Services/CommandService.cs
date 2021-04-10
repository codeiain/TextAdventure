using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameServer.DTO;
using GameServer.Models;

namespace GameServer.Services
{
    public class CommandService : ICommandService
    {
        public CommandModel Command { get; set; }
        public List<Type> VeifiedCommands { get; set; }
        
        public CommandService(CommandModel command)
        {
            Command = command;
            VeifiedCommands = GetCommands("GameServer.Commands");
        }

        public string NormalisaAction(string action)
        {
            action = action.ToLower().Split(" ")[0];
            return action;
        }

        public Type verifyCommand()
        {
            if (Command == null) return null;
            if (Command.Action == null) return null;
            if (Command.Context == null) return null;

            var action = NormalisaAction(Command.Action);
            if (VeifiedCommands.Find(x=>x.Name.ToLower() == action) != null)
            {
                return VeifiedCommands.Find(x=>x.Name.ToLower() == action);
            }

            return null;
        }
        
        private List<Type> GetCommands(string nspace)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == nspace
                select t;
            return q.ToList();
        }

        public object Parse()
        {
            Type validsCommand = verifyCommand();
            if (validsCommand != null)
            {
                var type = Type.GetType(validsCommand.FullName ?? string.Empty);
                dynamic o = Activator.CreateInstance(type);
                o.SetData(Command);
                return o;
            }

            return null;
        }
        
        private T CreateInstance<T>(params object[] paramArray)
        {
            return (T)Activator.CreateInstance(typeof(T), args:paramArray);
        }
    }
}