using System;
using Arest2;
using CommandSystem;
using Exiled.API.Features;

namespace Cuff
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Cuff : ICommand
    {       
        public string Command { get; } = "cuff";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Арестовать ниг";

        public bool Execute(ArraySegment<string> arguments, PlayerCommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = "Usage: cuff [Игрок]";
                return false;
            }

            Player player = Player.Get(sender.PlayerId);
            if (player is null)
            {
                response = $"Нет цели: {arguments.At(0)}";
                return false;
            }
            
            var cuffer = Player.Get((sender as CommandSender)?.SenderId);
            CuffController.StartCuff(player, cuffer, out response);
            
            return true;
        }
    }
}
