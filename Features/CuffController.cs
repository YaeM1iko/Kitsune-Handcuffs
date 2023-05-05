using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using MEC;

namespace Arest2
{
    public static class CuffController
    {
        public static IDictionary Handcuffed { get; } = new Dictionary<Player, Player>();

        public static bool IsUsing(Player ply)
        {
            foreach (var target in Handcuffed.Values)
            {
                if (target == ply)
                    return true;
            }

            return false;
        }

        public static void StartCuff(Player target, Player cuffer, out string response)
        {
            if (IsUsing(target))
            {
                response = "Уже связан!";
                return;
            }

            if (target.CurrentItem != null)
            {
                response = "Невозможно связать!";
                return;
            }
            
            Handcuffed.Add(cuffer, target);
            
            target.Handcuff();               
            target.DropItems();
            
            target.Broadcast(10, $"<color=green>Вас связал {cuffer.Nickname}</color>");
            
            response = $" {target.Nickname} был связан!";

            Timing.CallDelayed(90f, () =>
            {
                if (target.IsCuffed)
                {
                    EndCuff(cuffer, target);
                }
            });
        }

        public static void EndCuff(Player cuffer, Player target)
        {
            target.RemoveHandcuffs();
            target.Broadcast(10, $"<color=green>Вы развязаны!</color>");
            Handcuffed.Remove(cuffer);
        }
    }
}