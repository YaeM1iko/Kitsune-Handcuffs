using Exiled.Events.EventArgs.Player;

namespace Arest2.Handlers
{
    public class Player
    {
        public void OnDied(DiedEventArgs e)
        {
            foreach (Exiled.API.Features.Player cuffer in CuffController.Handcuffed.Keys)
            {
                if (e.Player == cuffer || 
                    (CuffController.Handcuffed.Contains(cuffer) 
                     && e.Player == CuffController.Handcuffed[cuffer]))
                {
                    var target = CuffController.Handcuffed[cuffer] as Exiled.API.Features.Player;
                    CuffController.EndCuff(cuffer, target);
                    return;
                }
            }
        }
    }
}