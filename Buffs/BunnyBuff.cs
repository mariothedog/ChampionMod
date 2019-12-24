using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Buffs
{
    public class BunnyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bunny");
            Description.SetDefault("The bunny will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.ownedProjectileCounts[mod.ProjectileType("Bunny")] > 0)
            {
                modPlayer.BunnyMinion = true;
            }

            if (!modPlayer.BunnyMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}