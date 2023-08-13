using Hazel;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using static TOHE.Options;
using static TOHE.Translator;

namespace TOHE.Roles.Crewmate;
public static class Cleanser
{
    private static readonly int Id = 23420;
    public static List<byte> playerIdList = new();
    public static Dictionary<byte,byte> CleanserTarget = new();
    public static Dictionary<byte, int> CleanserUses = new();
    public static List<byte> CleansedPlayers = new();
    public static Dictionary<byte, bool> DidVote = new();

    public static OptionItem CleanserUsesOpt;
    public static OptionItem CleansedCanGetAddon;

    public static void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.CrewmateRoles, CustomRoles.Cleanser);
        CleanserUsesOpt = IntegerOptionItem.Create(Id + 10, "MaxCleanserUses", new(1, 14, 1), 3, TabGroup.CrewmateRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Cleanser])
            .SetValueFormat(OptionFormat.Times);
        CleansedCanGetAddon = BooleanOptionItem.Create(Id + 11, "CleansedCanGetAddon", false, TabGroup.CrewmateRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Cleanser]);

    }
    public static void Init()
    {
        playerIdList = new();
        CleanserTarget = new();
        CleanserUses = new();
        CleansedPlayers = new();
        DidVote = new();
    }

    public static void Add(byte playerId)
    {
        playerIdList.Add(playerId);
        CleanserTarget.Add(playerId, byte.MaxValue);
        CleanserUses.Add(playerId, 0);
        DidVote.Add(playerId, false);
    }

    public static bool IsEnable => playerIdList.Any();

    public static string GetProgressText(byte playerId) => Utils.ColorString(CleanserUsesOpt.GetInt() - CleanserUses[playerId] > 0 ? Utils.GetRoleColor(CustomRoles.Cleanser).ShadeColor(0.25f) : Color.gray, CleanserUses.TryGetValue(playerId, out var x) ? $"({CleanserUsesOpt.GetInt() - x})" : "Invalid");

    private static void SendRPC(byte playerId)
    {
        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCleanserCleanLimit, SendOption.Reliable, -1);
        writer.Write(playerId);
        writer.Write(CleanserUses[playerId]);
        AmongUsClient.Instance.FinishRpcImmediately(writer);
    }

    public static void ReceiveRPC(MessageReader reader)
    {
        byte CleanserId = reader.ReadByte();
        int Limit = reader.ReadInt32();
        if (CleanserUses.ContainsKey(CleanserId))
            CleanserUses[CleanserId] = Limit;
        else
            CleanserUses.Add(CleanserId, 0);
    }

    public static void OnVote(PlayerControl voter, PlayerControl target)
    {
        if (!voter.Is(CustomRoles.Cleanser)) return;
        if (DidVote[voter.PlayerId]) return;
        DidVote[voter.PlayerId] = true;
        if (CleanserUses[voter.PlayerId] > CleanserUsesOpt.GetInt()) return;
        if (target.PlayerId == voter.PlayerId)
        {
            Utils.SendMessage(GetString("CleanserRemoveSelf"), voter.PlayerId, Utils.ColorString(Utils.GetRoleColor(CustomRoles.Cleanser), GetString("CleanserTitle")));
            return;
        }
        if (CleanserTarget[voter.PlayerId] != byte.MaxValue) return;

        CleanserUses[voter.PlayerId]++;
        CleanserTarget[voter.PlayerId] = target.PlayerId;
        Logger.Info($"{voter.GetNameWithRole()} cleansed {target.GetNameWithRole()}", "Cleansed");
        CleansedPlayers.Add(target.PlayerId);
        Utils.SendMessage(string.Format(GetString("CleanserRemovedRole"), target.GetRealName()), voter.PlayerId, title: Utils.ColorString(Utils.GetRoleColor(CustomRoles.Cleanser),"CleanserTitle"));
        SendRPC(voter.PlayerId);
    }

    public static void AfterMeetingTasks()
    {
        foreach(var pid in CleanserTarget.Keys)
        {
            DidVote[pid] = false;
            if (pid == byte.MaxValue) continue;
            var targetid = CleanserTarget[pid];
            if (targetid == byte.MaxValue) continue;
            var targetpc = Utils.GetPlayerById(targetid);
            if (targetpc == null || targetpc.Data.IsDead) continue;
            //var allAddons = targetpc.GetCustomSubRoles();
            if (targetpc.Is(CustomRoles.Lovers))
            {
                foreach (var loversPlayer in Main.LoversPlayers)
                {
                    //生きていて死ぬ予定でなければスキップ
                    if (!loversPlayer.Data.IsDead && loversPlayer.PlayerId != targetpc.PlayerId) continue;

                    foreach (var partnerPlayer in Main.LoversPlayers)
                    {
                        //本人ならスキップ
                        if (loversPlayer.PlayerId == partnerPlayer.PlayerId) continue;

                        //残った恋人を全て殺す(2人以上可)
                        //生きていて死ぬ予定もない場合は心中
                        if (partnerPlayer.PlayerId != targetpc.PlayerId && !partnerPlayer.Data.IsDead)
                        {
                            if (partnerPlayer.Is(CustomRoles.Lovers))
                            {
                                partnerPlayer.RpcSetCustomRole(CustomRoles.Cleansed);
                                partnerPlayer.Notify(GetString("LostAddonByCleanser"));
                                Logger.Info($"Removed all the add ons of {partnerPlayer.GetNameWithRole()}", "Cleanser-lover");
                            }
                        }
                    }
                }
            }
            targetpc.RpcSetCustomRole(CustomRoles.Cleansed);
            Logger.Info($"Removed all the add ons of {targetpc.GetNameWithRole()}", "Cleanser");
            //foreach (var role in allAddons)
            //{
            //    Main.PlayerStates[targetid].RemoveSubRole(role);

            //}
            CleanserTarget[pid] = byte.MaxValue;
            targetpc.Notify(GetString("LostAddonByCleanser"));

        }
        Utils.MarkEveryoneDirtySettings();


    }

}
