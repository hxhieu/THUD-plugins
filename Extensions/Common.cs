namespace Turbo.Plugins.User.Extensions
{
    public class DestructablePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public DestructablePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }

    public static class SkillExtensions
    {
        public static bool CanUse(this IPlayerSkill skill)
        {
            return !skill.IsOnCooldown
                && skill.ResourceCost <= skill.Player.Stats.ResourceCurPri
            ;
        }
    }
}