using BepInEx;
using BepInEx.Unity.IL2CPP;
using Il2CppSystem.IO;
using UnityEngine;
using WildfrostModMiya;

namespace WildfrostReptileFaction;

[BepInPlugin("Wildfrost.ArtlessAvian.ReptileFaction", "ReptileFaction", "0.1.0")]
[BepInDependency("WildFrost.Miya.WildfrostAPI")]
public class WildfrostReptileFaction : BasePlugin
{
    // Taken from library code.
    public static readonly string PluginFolder = typeof(WildfrostReptileFaction).Assembly.Location.Replace("WildfrostReptileFaction.dll", "");

    // static StatusEffectData whenSnowAppliedToSelfGainTeeth;

    public override void Load()
    {
        Log.LogInfo("helllllooooo");
        Log.LogInfo("loaded at " + PluginFolder);

        CardAdder.OnAskForAddingCards += (int i) =>
        {
            Log.LogInfo("Adding Gates");

            CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Gates")
                .SetIsUnit()
                .SetStats(12, 1, 0)
                .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
                .SetStartWithEffects(
                    // CardAdder.VanillaStatusEffects.WhenHitTriggerToSelf.StatusEffectStack(1),
                    CardAdder.VanillaStatusEffects.WhenSnowAppliedToSelfGainEqualAttack.StatusEffectStack(1)
                )
                .SetTraits(
                    CardAdder.VanillaTraits.Smackback.TraitStack(1)
                )
                // Flavor
                .SetTitle("Gates")
                .SetSprites(LoadSprite("assets/gates/sketch1690163284004.png"), LoadSprite("assets/gates/white.png"))
                // Metagame
                .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
                .RegisterCardInApi();
        };

        // Commented because not fun, needs work.
        CardAdder.OnAskForAddingCards += (int i) =>
        {
            Log.LogInfo("Adding Reggie");
            CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Reggie")
                .SetIsUnit()
                .SetStats(5, 6, 2)
                .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
                .SetStartWithEffects(
                    CardAdder.VanillaStatusEffects.Snow.StatusEffectStack(3)
                )
                // Flavor
                .SetTitle("Reggie")
                .SetText("Start with 3 <keyword=snow>.")
                .SetSprites(LoadSprite("assets/gates/sketch1690163284004.png"), LoadSprite("assets/gates/white.png"))
                // Metagame
                // .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
                .RegisterCardInApi();
        };

        CardAdder.OnAskForAddingCards += (int i) =>
        {
            Log.LogInfo("Adding Scorpy");
            CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Scorpy")
                .SetIsUnit()
                .SetStats(9, 4, 3)
                .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
                .SetTraits(
                    CardAdder.VanillaTraits.Pull.TraitStack(1),
                    CardAdder.VanillaTraits.Longshot.TraitStack(1)
                )
                // Flavor
                .SetTitle("Scorpy")
                .SetSprites(LoadSprite("assets/gates/sketch1690163284004.png"), LoadSprite("assets/gates/white.png"))
                // Metagame
                // .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
                .RegisterCardInApi();
        };

        CardAdder.OnAskForAddingCards += (int i) =>
        {
            Log.LogInfo("Adding Colbo");

            CardData cardData = CardAdder.CreateCardData("ReptileFaction", "Colbo")
                .SetIsUnit()
                .SetStats(1, 1, 2)
                .SetCanPlay(CardAdder.CanPlay.CanPlayOnBoard)
                // TODO: On hit gain gold. Or ink or status or idk.
                .SetAttackEffects(
                    CardAdder.VanillaStatusEffects.GainGold.StatusEffectStack(2)
                )
                .SetTraits(
                    CardAdder.VanillaTraits.Longshot.TraitStack(1)
                )
                // Flavor
                .SetTitle("Colbo")
                .SetText("On hit, gain 2 bling") // TODO: Find and use bling keyword
                .SetSprites(LoadSprite("assets/gates/sketch1690163284004.png"), LoadSprite("assets/gates/white.png"))
                // Metagame
                // .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
                .RegisterCardInApi();
        };

        CardAdder.OnAskForAddingCards += (int i) =>
        {
            // Log.LogInfo("Adding RemoveSnow");
            // StatusEffectAdder.CreateStatusEffectData<StatusEffectApplyXOnTurn>("ReptileFaction", "RemoveSnow")
            //     .
            Log.LogInfo("Adding HeatLamp");

            CardData cardData = CardAdder.CreateCardData("ReptileFaction", "HeatLamp")
                .SetIsUnit()
                .SetStats(null, null, 2)
                .SetCanPlay(CardAdder.CanPlay.CanPlayOnFriendly)
                .SetStartWithEffects(
                    CardAdder.VanillaStatusEffects.Scrap.StatusEffectStack(5),
                    CardAdder.VanillaStatusEffects.ImmuneToSnow.StatusEffectStack(1),
                    // TODO: Replace me
                    CardAdder.VanillaStatusEffects.OnTurnHealAllies.StatusEffectStack(1)
                )
                .SetAttackEffects(
                    CardAdder.VanillaStatusEffects.LoseScrap.StatusEffectStack(1)
                )
                // Flavor
                .SetTitle("Heat Lamp")
                // .SetText("Remove 1 <keyword=snow> from all units")
                .SetSprites(LoadSprite("assets/gates/sketch1690163284004.png"), LoadSprite("assets/gates/white.png"))
                // Metagame
                // .AddToPool(CardAdder.VanillaRewardPools.GeneralUnitPool)
                .RegisterCardInApi();
        };
    }

    private static Sprite LoadSprite(string path)
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(File.ReadAllBytes(PluginFolder + path));
        return tex.ToSprite();
    }
}
