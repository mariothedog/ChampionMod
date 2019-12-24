using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Buffs
{
    public class PrimalClumpBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Description.SetDefault("The primal clump will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("PrimalClump")] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}