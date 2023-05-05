using System;
using Arest2;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using FMODUnity;
using MEC;
using RemoteAdmin;


namespace Uncuff
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Uncuff : ICommand
    {
        public string Command { get; } = "uncuff";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Снять наручники";

        public bool Execute(ArraySegment<string> arguments, PlayerCommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = "Usage: uncuff на Игрока";
                return false;
            }

            Player player = Player.Get(sender.PlayerId);
            if (player is null)
            {
                response = $"нет цели: {arguments.At(0)}";
                return false;
            }

            var cuffer = Player.Get((sender as CommandSender)?.SenderId);
            CuffController.EndCuff(cuffer, player);
            
            response = "Наручники упали!";
            return true;
        }
    }
}