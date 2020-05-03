// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
// *.txt files are not loaded automatically by TurboHUD
// you have to change this file's extension to .cs to enable it
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

using Turbo.Plugins.Default;
using System.Linq;
using Turbo.Plugins.User.BuffWatcher.Painter;

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