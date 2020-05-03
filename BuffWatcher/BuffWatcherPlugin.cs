using Turbo.Plugins.Default;
using Turbo.Plugins.User.Painters;

namespace Turbo.Plugins.User.BuffWatcher
{

    public class BuffWatcherPlugin : BasePlugin, IInGameTopPainter
    {
        private CentreSlotPainter _centreSlot;
        public BuffWatcherPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            _centreSlot = new CentreSlotPainter(hud);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            var might = Hud.Game.Me.Powers.GetBuff("P4_ItemPassive_Unique_Ring_049");
            _centreSlot.Paint(might);
        }
    }
}