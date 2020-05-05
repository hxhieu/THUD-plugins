using System.Linq;
using Turbo.Plugins.Default;
using Turbo.Plugins.User.Painters;
using Turbo.Plugins.User.Extensions;

namespace Turbo.Plugins.User.SkillLogger
{
    public class SkillLoggerPlugin : BasePlugin, IBeforeRenderHandler// ISkillCooldownHandler//, IBeforeRenderHandler//, IInGameTopPainter
    {
        static string LastLog = string.Empty;

        private ScreenDebugPainter _debugPainter;

        // Settings
        private const bool DEBUG = false;
        private const int MIN_MONSTER = 4;
        private const int MIN_DISTANCE = 20;

        public SkillLoggerPlugin()
        {
            Enabled = true;
            Order = int.MinValue;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            _debugPainter = new ScreenDebugPainter(hud);
        }

        // public void PaintTopInGame(ClipState clipState)
        // {
        //     if (clipState != ClipState.AfterClip) return;
        //     WriteLog();
        // }

        private void WriteLog()
        {
            var player = Hud.Game.Me;
            if (!DEBUG)
            {
                var monsters = Hud.Game.AliveMonsters.Where(x => x.NormalizedXyDistanceToMe <= MIN_DISTANCE && x.IsOnScreen && !x.Invisible).ToArray();
                var elites = monsters.Where(x => x.IsElite).ToArray();
                if (monsters.Length < MIN_MONSTER && elites.Length <= 0) return;
            }

            var log = "[";
            //var log = string.Empty;

            foreach (var skill in player.Powers.CurrentSkills)
            {
                // Skip mouse skills
                if (skill.Key == ActionKey.LeftSkill || skill.Key == ActionKey.RightSkill) continue;
                log += "{";
                log += $"\"Key\":\"{skill.Key}\",";
                log += $"\"CanUse\":{skill.CanUse().ToString().ToLower()}";
                log += "},";
                // log += $"{skill.CanUse()}|";
            }
            log = log.TrimEnd(',');
            log += "]";
            if (LastLog != log)
            {
                LastLog = log;
                Hud.TextLog.Log("skills", LastLog, false, false);
            }
        }

        public void BeforeRender()
        {
            WriteLog();
        }
    }
}