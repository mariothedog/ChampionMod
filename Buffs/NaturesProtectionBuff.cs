using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Buffs
{
    public class NaturesProtectionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nature's Protection");
            Description.SetDefault("Increased health regeneration");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; // So the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 2;
        }
    }
}