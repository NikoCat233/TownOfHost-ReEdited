using System;
using System.Collections.Generic;
using System.Linq;
using AmongUs.Data;
using AmongUs.Data.Player;
using Assets.InnerNet;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TOHE;

// ##https://github.com/Yumenopai/TownOfHost_Y
public class ModNews
{
    public int Number;
    public int BeforeNumber;
    public string Title;
    public string SubTitle;
    public string ShortTitle;
    public string Text;
    public string Date;

    public Announcement ToAnnouncement()
    {
        var result = new Announcement
        {
            Number = Number,
            Title = Title,
            SubTitle = SubTitle,
            ShortTitle = ShortTitle,
            Text = Text,
            Language = (uint)DataManager.Settings.Language.CurrentLanguage,
            Date = Date,
            Id = "ModNews"
        };

        return result;
    }
}
[HarmonyPatch]
public class ModNewsHistory
{
    public static List<ModNews> AllModNews = new();

    // When creating new news, you can not delete old news 
    public static void Init()
    {
    // ====== English ======
        if (TranslationController.Instance.currentLanguage.languageID == SupportedLangs.English)
        {
            {
                // TOHE v3.0.0
                var news = new ModNews
                {
                    Number = 100002,
                    Title = "Town of Host Re-Edited v3.0.0",
                    SubTitle = "★★The next big update!★★",
                    ShortTitle = "★TOH-RE v3.0.0",
                    Text = "<size=150%>Welcome to TOHE v3.0.0!</size>\n\n<size=125%>Support for Among Us v2023.7.11 and v2023.7.12</size>\n"

                        + "\n<b>【Base】</b>\n - Base on TOH v4.1.2\r\n"

                        + "\n<b>【New Roles】</b>" +
                        "\n\r<b><i>Impostor: (5 roles)</i></b>" +
                            "\n     - Nuker (hidden)" +
                            "\n     - Pitfall" +
                            "\n     - Godfather" +
                            "\n     - Ludopath" +
                            "\n     - Berserker\n\r" +

                        "\n\r<b><i>Crewmate: (13 roles)</i></b>" +
                            "\n     - Admirer" +
                            "\n     - Copycat" +
                            "\n     - Time Master" +
                            "\n     - Crusader" +
                            "\n     - Reverie" +
                            "\n     - Lookout" +
                            "\n     - Telecommunication" +
                            "\n     - Chameleon" +
                            "\n     - Cleanser" +
                            "\n     - Lighter (Add-on: Lighter renamed to Torch)" +
                            "\n     - Task Manager" +
                            "\n     - Jailor" +
                            "\n     - Swapper (Experimental role)\n\r" +

                        "\n\r<b><i>Neutral: (17 roles)</i></b>" +
                            "\n     - Amnesiac" +
                            "\n     - Plaguebearer/Pestilence" +
                            "\n     - Masochist" +
                            "\n     - Doomsayer" +
                            "\n     - Pirate" +
                            "\n     - Shroud" +
                            "\n     - Werewolf" +
                            "\n     - Shaman" +
                            "\n     - Occultist" +
                            "\n     - Shade" +
                            "\n     - Romantic (Vengeful Romantic & Ruthless Romantic)" +
                            "\n     - Seeker" +
                            "\n     - Agitater" +
                            "\n     - Soul Collector\n\r" +

                        "\n\r<b><i>Added new faction: Coven: (10 roles)</i></b>" +
                            "\n     - Banshee" +
                            "\n     - Coven Leader" +
                            "\n     - Necromancer" +
                            "\n     - Potion Master" +
                            "\n     - Moved Jinx to coven" +
                            "\n     - Moved Hex Master to coven" +
                            "\n     - Moved Medusa to coven" +
                            "\n     - Moved Poisoner to coven" +
                            "\n     - Moved Ritualist to coven" +
                            "\n     - Moved Wraith to coven\n\r" +

                        "\n\r<b><i>Add-on: (12 add-ons)</i></b>" +
                            "\n     - Ghoul" +
                            "\n     - Unlucky" +
                            "\n     - Oblivious (returned)" +
                            "\n     - Diseased" +
                            "\n     - Antidote" +
                            "\n     - Burst" +
                            "\n     - Clumsy" +
                            "\n     - Sleuth" +
                            "\n     - Aware" +
                            "\n     - Fragile" +
                            "\n     - Repairman" +
                            "\n     - Void Ballot\n\r" +

                        "\n\r<b>【Rework Roles/Add-ons】</b>" +
                            "\n     - Bomber" +
                            "\n     - Medic" +
                            "\n     - Jackal" +
                            "\n     - Trapster" +
                            "\n     - Mare (is now an add-on)\n\r" +

                        "\n\r<b>【Bug Fixes】</b>" +
                            "\n     - Fixed Torch" +
                            "\n     - Fixed fatal error on Crusader" +
                            "\n     - Fixed long loading time for game with mod" +
                            "\n     - Jinx should no longer be able to somehow jinx themself" +
                            "\n     - Cursed Wolf should no longer be able to somehow curse themself" +
                            "\n     - Fixed bug when extra title appears in settings mod" +
                            "\n     - Fixed bug when modded non-host can't guess add-ons and some roles" +
                            "\n     - Fixed bug when some roles could not get Add-ons" +
                            "\n     - Fixed a bug where the text \"Devoured\" did not appear for the player" +
                            "\n     - Fixed bug where non-Lovers players would dead together" +
                            "\n     - Fixed bug when shield in-lobby caused by Vulture cooldown up" +
                            "\n     - Fixed bug where role Tracefinder sometime did not have arrows" +
                            "\n     - Fixed bug when setting \"Neutrals Win Together\" doesn't work" +
                            "\n     - Fixed Bug When Some Neutrals Cant Click Sabotage Button (Host)" +
                            "\n     - Fixed Bug When Puppeteer and Witch Dont Sees Target Mark" +
                            "\n     - Fixed Zoom" +
                            "\n     - Some fixes black screen" +
                            "\n     - Some Fix for Sheriff" +
                            "\n     - Fixed Tracker Arrow" +
                            "\n     - Fixed Divinator" +
                            "\n     - Fixed some add-on conflicts" +
                            "\n     - Fixed Report Button Icon\n\r" +

                        "\n\r<b>【Improvements Roles】</b>" +
                            "\n     - Fortune Teller" +
                            "\n     - Serial Killer" +
                            "\n     - Camouflager" +
                            "\n     - Retributionist Balancing" +
                            "\n     - Setting: Arsonist keeps the game going" +
                            "\n     - Vector setting: Vent Cooldown" +
                            "\n     - Jester setting: Impostor Vision" +
                            "\n     - Avenger setting: Crewmates/Neutrals can become Avenger" +
                            "\n     - Judge Can TrialIs Coven" +
                            "\n     - Setting: Torch is affected by Lights Sabotage" +
                            "\n     - SS Duration and CD setting for Miner and Escapist" +
                            "\n     - Added ability use limit for Time Master and Grenadier" +
                            "\n     - Added the ability to increase abilities when completing tasks for: Coroner, Chameleon, Tracker, Mechanic, Oracle, Inspector, Medium, Fortune Teller, Grenadier, Veteran, Time Master, and Pacifist" +
                            "\n     - Setting to hide the shot limit for Sheriff" +
                            "\n     - Setting for Fortune Teller whether it shows specific roles instead of clues on task completion" +
                            "\n     - Settings for Tracefinder that determine a delay in when the arrows show up" +
                            "\n     - Setting for Mortician whether it has arrows toward bodies or not" +
                            "\n     - Setting for Oracle that determines the chance of showing an incorrect result" +
                            "\n     - Settings for Mechanic that determine how many uses it takes to fix Reactor/O2 and Lights/Comms" +
                            "\n     - Setting for Swooper, Wraith, Chameleon, and Shade that determines if the player can vent normally when invisibility is on cooldown" +
                            "\n     - Setting: Bait Can Be Reported Under All Conditions" +
                            "\n     - Chameleon uses the engineer vent cooldown" +
                            "\n     - Vampire and Poisoner now have their cooldowns reset when the bitten/poisoned player dies\n\r" +

                        "\n\r<b>【New Client Settings】</b>" +
                            "\n     - Show FPS" +
                            "\n     - Game Master (GM) (has been moved)" +
                            "\n     - Text Overlay" +
                            "\n     - Small Screen Mode" +
                            "\n     - Old Role Summary\n\r" +

                        "\n\r<b>【New Mod Settings】</b>" +
                            "\n     - Use Protection Anti Blackout" +
                            "\n     - Killer count command (Also includes /kcount command)" +
                            "\n     - See ejected roles in meetings" +
                            "\n     - Remove pets at dead players (Vanilla bug fix)" +
                            "\n     - Setting to disable unnecessary shield animations" +
                            "\n     - Setting to hide the kill animation when guesses happen" +
                            "\n     - Disable comms camouflage on some maps" +
                            "\n     - Block Switches When They Are Up" +
                            "\n     - Sabotage Cooldown Control" +
                            "\n     - Reset Doors After Meeting (Airship/Polus)\n\r" +

                        "\n\r<b>【Some Changes】</b>" +
                            "\n     - Victory and Defeat text is no longer role colored" +
                            "\n     - Last Impostor can no longer be guessed" +
                            "\n     - Tasks from a crewmate lover now count towards a task win" +
                            "\n     - Infected players now die after a meeting if there's no alive Infectious" +
                            "\n     - Body reports during camouflage is now separated" +
                            "\n     - Trapster, Vector, Egoist, Revolutionist, Provocateur, Guesser are no longer experimental" +
                            "\n     - Added ability to change settings by 5 instead of 1 when holding the Left/Right Shift key" +
                            "\n     - All ability cooldowns are now reset after meetings" +
                            "\n     - Lovers can not become Sunnyboy" +
                            "\n     - Task bar always set to none" +
                            "\n     - Hangman moved to experimental due to bugs" +
                            "\n     - Roles with an add-on equivalent will not spawn if the add-on is enabled" +
                            "\n     - \"/r\" command has been improved\n\r" +

                        "\n\r<b>【New Features】</b>" +
                            "\n     - Load time reduced significantly" +
                            "\n     - The mod has been translated to Spanish (Partially)" +
                            "\n     - The mod has been translated to Chinese" +
                            "\n     - Improvement Random Map" +
                            "\n     - Main menu has been changed" +
                            "\n     - Added new buttons in main menu" +
                            "\n     - Added Auto starting features" +
                            "\n     - Reworked Discord Rich Presence" +
                            "\n     - Moderator and Sponsor improvement (/kick, /ban, /warn, and Moderator tags)" +
                            "\n     - Default template file has been updated" +
                            "\n     - Reworked end game summary (In the settings you can also return the old)" +
                            "\n     - Improvement platform kick" +
                            "\n     - Check Supported Version Among Us\n\r" +

                        "\n\r<b>【Removals】</b>" +
                            "\n     - Removed Solo PVP mode" +
                            "\n     - Removed Neptune" +
                            "\n     - Removed Capitalist",

                    Date = "2023-9-16T00:00:00Z"

                };
                AllModNews.Add(news);
            }

            {
                // TOHE v2.5.0
                var news = new ModNews
                {
                    Number = 100001,
                    Title = "TownOfHostEdited v2.5.0",
                    SubTitle = "★★★★Another big update, maybe bigger?★★★★",
                    ShortTitle = "★TOHE v2.5.0",
                    Text = "<size=150%>Welcome to TOHE v2.5.0.</size>\n\n<size=125%>Support for Among Us v2023.7.11 and v2023.7.12</size>\n"

                        + "\n【Base】\n - Base on TOH v4.1.2\r\n"
                        + "\n【Fixes】\n - Various bug fixes\n\r"
                        + "\n【Changes】\n - Hex Master hex icon changed to separate it from Spellcaster\n - Fortune Teller moved to Experimentals due to a planned and unfinished rework\n\r"

                        + "\n【New Features】\n - New role: Twister (role by papercut on Discord)\n\r - New role: Chameleon (from Project: Lotus)\n\r - New role: Morphling\n\r - New role: Inspector (role by ryuk on Discord)\n\r - New role: Medusa\n\r - New add-on: Lazy\n\r - New add-on: Gravestone\n\r - New add-on: Autopsy (from TOHY)\n\r - New add-on: Loyal\n\r - New add-on: Visionary\n\r- New experimental role: Spiritcaller (role by papercut on Discord)\n\r"

                        + "\n【Role Changes】\n - Various changes were made, such as an update to Opportunist\n\r",

                    Date = "2023-7-14T00:00:00Z"

                };
                AllModNews.Add(news);
            }

            {
                // TOHE v2.4.2
                var news = new ModNews
                {
                    Number = 100000,
                    Title = "TownOfHostEdited v2.4.2",
                    SubTitle = "★★★★Ooooh bigger update★★★★",
                    ShortTitle = "★TOHE v2.4.2",
                    Text = "Added in some new stuff, along with some bug fixes.\r\nAmong Us v2023.3.28 is recommended so the roles work correctly.\n"

                        + "\n【Base】\n - Base on TOH v4.1.2\r\n"
                        + "\n【Fixes】\n - Fixed various black screen bugs (some still exist but should be less common)\r\n - Other various bug fixes (they're hard to keep track of)\r\n"
                        + "\n【Changes】\n - Judge now supports Guesser Mode\r\n - Background image reverted to use the AU v2023.3.28 size due to the recommended Among Us version being v2023.3.28\r\n - Many other unlisted changes\r\n - Mario renamed to Vector due to copyright concerns\r\n"

                        + "\n【New Features】\n - ###Impostors\n - Councillor\r\n - Deathpact (role by papercut on Discord)\r\n - Saboteur (25% chance to replace Inhibitor)\r\n - Consigliere (by Yumeno from TOHY)\r\n - Dazzler (role by papercut on Discord)\r\n - Devourer (role by papercut on Discord)\r\n"
                        + "\n ### Crewmates\n - Addict (role by papercut on Discord)\r\n - Tracefinder\r\n - Deputy\r\n - Merchant (role by papercut on Discord)\r\n - Oracle\r\n - Spiritualist (role by papercut on Discord)\r\n - Retributionist\r\n- Guardian\r\n - Monarch\r\n"
                        + "\n ### Neutrals\n - Maverick\r\n - Cursed Soul\r\n - Vulture (role by ryuk on Discord)\r\n - Jinx\r\n - Pickpocket\r\n - PotionMaster\r\n - Traitor\r\n"
                        + "\n ### Add-ons\n - Double Shot (add-on by TommyXL)\r\n - Rascal\r\n"

                        + "\n【Role Changes】\n - Mimic now has a setting to see the roles of dead players, due to how useless this add-on was\r\n - A revealed Workaholic can no longer be guessed\r\n - Doctor has a new setting like Workaholic to be revealed to all (currently exposes evil Doctors, use at your own risk)\r\n - Mayor has a setting for a TOS mechanic to reveal themselves\r\n - Warlock balancing\r\n - Cleaner balancing (resets kill cooldown to value set in Cleaner settings)\r\n - Updated Monarch\r\n- Removed speed boost from Mare\r\n"
                        + "\n【Removals】\n - Removed Flash\r\n - Removed Speed Booster\r\n - Temporarily removed Oblivious",

                    Date = "2023-7-5T00:00:00Z"

                };
                AllModNews.Add(news);
            }
        }
    // ====== Russian ======
        else if (TranslationController.Instance.currentLanguage.languageID == SupportedLangs.Russian)
        {
            {
                // TOHE v3.0.0
                var news = new ModNews
                {
                    Number = 90000,
                    Title = "Town of Host Re-Edited v3.0.0",
                    SubTitle = "★★Следующее большое обновление!★★",
                    ShortTitle = "★TOH-RE v3.0.0",
                    Text = "<size=150%>Добро Пожаловать в TOHE v3.0.0!</size>\n\n<size=125%>Поддерживает версию Among Us v2023.7.11 и v2023.7.12</size>\n"

                        + "\n<b>【Основан】</b>\n - Основан на TOH v4.1.2\r\n"

                        + "\n<b>【Новые роли】</b>" +
                        "\n\r<b><i>Предатель: (5 ролей)</i></b>" +
                            "\n     - Крипер (скрытый)" +
                            "\n     - Ловушка" +
                            "\n     - Крестный" +
                            "\n     - Людопат" +
                            "\n     - Берсерк\n\r" +

                        "\n\r<b><i>Член Экипажа: (13 ролей)</i></b>" +
                            "\n     - Поклонник" +
                            "\n     - Подражатель" +
                            "\n     - Повелитель Времени" +
                            "\n     - Крестоносец" +
                            "\n     - Мечтатель" +
                            "\n     - Дозорный" +
                            "\n     - Коммуникатор" +
                            "\n     - Хамелеон" +
                            "\n     - Очиститель" +
                            "\n     - Зажигалка" +
                            "\n     - Мастер Задач" +
                            "\n     - Тюремщик" +
                            "\n     - Обменник (Эксперементальная роль)\n\r" +

                        "\n\r<b><i>Нейтрал: (17 ролей)</i></b>" +
                            "\n     - Амнезияк" +
                            "\n     - Носитель Чумы/Чума" +
                            "\n     - Мазохист" +
                            "\n     - Предсказатель" +
                            "\n     - Пират" +
                            "\n     - Накрыватель" +
                            "\n     - Оборотень" +
                            "\n     - Шаман" +
                            "\n     - Окультист" +
                            "\n     - Романтик (Мстительный Романтик & Безжалостный Романтик)" +
                            "\n     - Тень" +
                            "\n     - Ищущий" +
                            "\n     - Агитатор" +
                            "\n     - Коллектор Душ\n\r" +

                        "\n\r<b><i>Добавлена ​​новая фракция: Ковен: (10 ролей)</i></b>" +
                            "\n     - Банши" +
                            "\n     - Лидер Ковена" +
                            "\n     - Некромант" +
                            "\n     - Ритуальщик" +
                            "\n     - Джинкс теперь роль Ковена" +
                            "\n     - Мастер Проклятий теперь роль Ковена" +
                            "\n     - Medusa теперь роль Ковена" +
                            "\n     - Отравитель теперь роль Ковена" +
                            "\n     - Фокусник теперь роль Ковена" +
                            "\n     - Дух теперь роль Ковена\n\r" +

                        "\n\r<b><i>Атрибут: (12 атрибутов)</i></b>" +
                            "\n     - Гуль" +
                            "\n     - Неудачный" +
                            "\n     - Забывчивый (возвращён)" +
                            "\n     - Мученик" +
                            "\n     - Антидот" +
                            "\n     - Взрывной" +
                            "\n     - Неуклюжий" +
                            "\n     - Сыщик" +
                            "\n     - Внимательный" +
                            "\n     - Пустой" +
                            "\n     - Механик" +
                            "\n     - Хрупкий\n\r" +

                        "\n\r<b>【Переработка Ролей/Атрибутов】</b>" +
                            "\n     - Бомбер" +
                            "\n     - Медик" +
                            "\n     - Шакал" +
                            "\n     - Ловец" +
                            "\n     - Ночной (теперь это атрибут)\n\r" +

                        "\n\r<b>【Исправление Багов】</b>" +
                            "\n     - Исправлен Фонарик" +
                            "\n     - Исправлена ​​фатальная ошибка у Крестоносца" +
                            "\n     - Исправлено долгое время загрузки игры с модом" +
                            "\n     - Джинкс больше не сможет каким-то образом сглазить себя" +
                            "\n     - Проклятый волк больше не сможет каким-либо образом проклинать себя" +
                            "\n     - Исправлена ​​ошибка, когда в настройках мода появлялся дополнительный заголовок" +
                            "\n     - Исправлена ​​ошибка, когда не-хост игрок с модом не мог угадать Атрибуты и некоторые роли" +
                            "\n     - Исправлена ​​ошибка, когда некоторые роли не могли получить Атрибуты" +
                            "\n     - Исправлена ​​ошибка, из-за которой игроки, не являющиеся Любовниками, умирали вместе" +
                            "\n     - Исправлена ​​ошибка, из-за которой щит в лобби появлялся из-за Стервятника" +
                            "\n     - Исправлена ​​ошибка, из-за которой у роли Искателя иногда не было стрелок" +
                            "\n     - Исправлена ​​ошибка, из-за которой настройка «Нейтралы побеждают вместе» не работала." +
                            "\n     - Исправлена ​​ошибка, когда некоторые нейтральные роли не могли нажать кнопку саботажа (Хост)." +
                            "\n     - Исправлена ​​ошибка, когда Кукловод и Заклинатель не могли видеть марку у цели." +
                            "\n     - Исправлен сломанный Зум" +
                            "\n     - Некоторые исправления черного экрана (И некоторая защита)" +
                            "\n     - Некоторые исправления у Шерифа" +
                            "\n     - Исправлены стрелки у Трекера" +
                            "\n     - Исправлен Следователь" +
                            "\n     - Исправлена ​​ошибка, когда текст «Поглощен» не появлялся у игрока" +
                            "\n     - Исправлены некоторые конфликты у Атрибутов" +
                            "\n     - Исправлен значок кнопки репорта у Хоста\n\r" +

                        "\n\r<b>【Улучшения Ролей】</b>" +
                            "\n     - Следователь" +
                            "\n     - Маньяк" +
                            "\n     - Камуфляжер" +
                            "\n     - Возмездник сбалансирован" +
                            "\n     - Настройка: Поджигатель продолжает игру" +
                            "\n     - Настройка у Вектора: Откат вентиляции" +
                            "\n     - Настройка у Шута: Имеет дальность обзора Предателя" +
                            "\n     - Настройка у Мстителя: Члены Экипажа/Нейтралы могут стать Мстителем" +
                            "\n     - Настройка у Судьи: Может судить Ковенов" +
                            "\n     - Настройка: Обзор Фонарика меняется при саботаже света" +
                            "\n     - Добавлена настройка продолжительности морфа у Шахтера и Баглаеца" +
                            "\n     - Добавлен лимит способности у Повелителя Времени и Гренадёр" +
                            "\n     - Добавлена ​​возможность повышения способностей при выполнении заданий для: Коронер, Хамелеон, Трекер, Ремонтник, Оракл, Инспектор, Медиум, Следователь, Гренадёр, Ветеран, Повелитель Времени и Пацифист" +
                            "\n     - Настройка позволяющая скрыть лимит выстрелов у Шерифа" +
                            "\n     - Настройка для Следователь, показывает ли он конкретные роли вместо подсказок после завершения заданий" +
                            "\n     - Настройка для Искателя, определяющие задержку появления стрелок" +
                            "\n     - Настройка для Гробовщика, может иметь стрелку которая введёт к труам" +
                            "\n     - Настройка Оракла, определяющая вероятность отображения неверного результата" +
                            "\n     - Настройки для Ремонтника позволет отнять количество способности при починке саботажа Реактора/O2 и Свет/Связь" +
                            "\n     - Настройка для Невидимки, Wraith, Хамелеона и Shade которая позволяет прыгать в вентиляцию когда невидимость находится в откате" +
                            "\n     - Настройка: Байт может быть зарепорчен при любых условиях" +
                            "\n     - Хамелеон использует откат вентиляции инженера" +
                            "\n     - Откат Вампира и Отравителя теперь сбрасывается, когда укушенный/отравленный игрок умирает\n\r" +

                        "\n\r<b>【Новые Клиентские Настройки】</b>" +
                            "\n     - Показывать FPS" +
                            "\n     - Мастер Игры (GM) (был перемещён)" +
                            "\n     - Наложение Текста (Показывать текст например как: Игра не закончится, Низкая Нагрузка и т.д.)" +
                            "\n     - Режим Маленького Экрана" +
                            "\n     - Старый Результат Игры (По умолчанию используется новый)\n\r" +

                        "\n\r<b>【Новые Настройки Мода】</b>" +
                            "\n     - Использовать защиту от чёрных экранов" +
                            "\n     - Включить использование команды /kcount" +
                            "\n     - Видеть роли изганных во время встречи" +
                            "\n     - Убрать питомцев у мёртвых игроков (Борьба с ванильным багом)" +
                            "\n     - Отключить ненужные анимации щитов" +
                            "\n     - Отключить анимацию убийств во время угадывания" +
                            "\n     - Отключить камуфляж на некоторых картах" +
                            "\n     - Блокировать переключатели когда они подняты" +
                            "\n     - Изменить откат саботажа" +
                            "\n     - Сбросить двери после встречи (Airship/Polus)\n\r" +

                        "\n\r<b>【Некоторые Изменения】</b>" +
                            "\n     - Текст победы и поражения больше не окрашивается от ролей" +
                            "\n     - Последнего Предатлея (Атрибут) больше невозможно угадать" +
                            "\n     - Задания от Членов Экипажа Любовников теперь засчитываются в счет победы по заданиям" +
                            "\n     - Зараженные игроки теперь умирают после встречи, если в живых нет Заразного" +
                            "\n     - Репорт трупа во время камуфляжа теперь разделены" +
                            "\n     - Ловец, Вектор, Эгоист, Революционист, Провокатор, Угадыватель больше не являются эксперементальными ролями" +
                            "\n     - Добавлена ​​возможность менять настройки на 5 вместо 1 при удержании Левого/Правого Shift." +
                            "\n     - Откат всех способностей теперь сбрасывается после встреч" +
                            "\n     - Любовники больше не могут стать Солнечным Мальчиком" +
                            "\n     - Панель задач теперь всегда отключена" +
                            "\n     - Вешатель перемещён в экспериментальные роли из-за багов" +
                            "\n     - Роли которые имеют те же способности что и Атрибуты не будут появляться, если эти Атрибуты включены" +
                            "\n     - Команда \"/r\" была улучшена\n\r" +

                        "\n\r<b>【Новые Функции】</b>" +
                            "\n     - Время загрузки мода теперь значительно ускорилась" +
                            "\n     - Мод переведён на Испанский (частично)" +
                            "\n     - Мод переведён на Китайский" +
                            "\n     - Улучшена настройка случайной карты" +
                            "\n     - Главное меню было изменено" +
                            "\n     - Добавлены новые кнопки в главном меню" +
                            "\n     - Добавлены функции для автоматического запуска" +
                            "\n     - Переработанн статус активности игры в профиле Дискорда" +
                            "\n     - Улучшение модератора и спонсора (/kick, /ban, /warn, и теги модератора)" +
                            "\n     - Файл шаблона по умолчанию был обновлен и улучшен" +
                            "\n     - Переработанн результат игры (В настройках клиента также можно вернуть старую)" +
                            "\n     - Улучшена настройка позволяющая кикать игроков играющих на дргуих платформах" +
                            "\n     - Добавлена проверка поддерживаемой версии Among Us\n\r" +

                            "\n\r<b>【Уделаены】</b>" +
                            "\n     - Удалён Режим ПВП" +
                            "\n     - Удалён атрибут Нептуна" +
                            "\n     - Удалена роль Капиталиста\n\r" +

                    "\n**Возможно указаны не все изменения, так как мог что-то упустить из виду**",

                    Date = "2023-9-10T00:00:00Z"

                };
                AllModNews.Add(news);
            }
        }
    // ====== SChinese ======
        else if (TranslationController.Instance.currentLanguage.languageID == SupportedLangs.SChinese)
        {
            {
                // TOHE v3.0.0
                var news = new ModNews
                {
                    Number = 80002,
                    Title = "Town of Host Re-Edited v3.0.0",
                    SubTitle = "★★The next big update!★★",
                    ShortTitle = "★TOH-RE v3.0.0",
                    Text = "<size=150%>Welcome to TOHE v3.0.0!</size>\n\n<size=125%>Support for Among Us v2023.7.11 and v2023.7.12</size>\n"

                        + "\n<b>【Base】</b>\n - Base on TOH v4.1.2\r\n"

                        + "\n<b>【New Roles】</b>" +
                        "\n\r<b><i>Impostor: (5 roles)</i></b>" +
                            "\n     - Nuker (hidden)" +
                            "\n     - Pitfall" +
                            "\n     - Godfather" +
                            "\n     - Ludopath" +
                            "\n     - Berserker\n\r" +

                        "\n\r<b><i>Crewmate: (16 roles)</i></b>" +
                            "\n     - Admirer" +
                            "\n     - Copycat" +
                            "\n     - Time Master" +
                            "\n     - Crusader" +
                            "\n     - Reverie" +
                            "\n     - Lookout" +
                            "\n     - Telecommunication" +
                            "\n     - Chameleon" +
                            "\n     - Cleanser" +
                            "\n     - Lighter (Add-on: Lighter renamed to Torch)" +
                            "\n     - Task Manager" +
                            "\n     - Romantic (Vengeful Romantic & Ruthless Romantic)" +
                            "\n     - Jailor" +
                            "\n     - Swapper (Experimental role)" +
                            "\n     - Police Commissioner\n\r" +

                        "\n\r<b><i>Neutral: (13 roles)</i></b>" +
                            "\n     - Amnesiac" +
                            "\n     - Plaguebearer/Pestilence" +
                            "\n     - Masochist" +
                            "\n     - Doomsayer" +
                            "\n     - Pirate" +
                            "\n     - Shroud" +
                            "\n     - Werewolf" +
                            "\n     - Shaman" +
                            "\n     - Occultist" +
                            "\n     - Shade" +
                            "\n     - Seeker" +
                            "\n     - Agitater" +
                            "\n     - Soul Collector\n\r" +

                        "\n\r<b><i>Added new faction: Coven: (10 roles)</i></b>" +
                            "\n     - Banshee" +
                            "\n     - Coven Leader" +
                            "\n     - Necromancer" +
                            "\n     - Potion Master" +
                            "\n     - Moved Jinx to coven" +
                            "\n     - Moved Hex Master to coven" +
                            "\n     - Moved Medusa to coven" +
                            "\n     - Moved Poisoner to coven" +
                            "\n     - Moved Ritualist to coven" +
                            "\n     - Moved Wraith to coven\n\r" +

                        "\n\r<b><i>Add-on: (11 add-ons)</i></b>" +
                            "\n     - Ghoul" +
                            "\n     - Unlucky" +
                            "\n     - Oblivious (returnet)" +
                            "\n     - Diseased" +
                            "\n     - Antidote" +
                            "\n     - Burst" +
                            "\n     - Clumsy" +
                            "\n     - Sleuth" +
                            "\n     - Aware" +
                            "\n     - Fragile" +
                            "\n     - Void Ballot\n\r" +

                        "\n\r<b>【Rework Roles/Add-ons】</b>" +
                            "\n     - Bomber" +
                            "\n     - Medic" +
                            "\n     - Jackal" +
                            "\n     - Mare (is now an add-on)\n\r" +

                        "\n\r<b>【Bug Fixes】</b>" +
                            "\n     - Fixed Torch" +
                            "\n     - Fixed fatal error on Crusader" +
                            "\n     - Fixed long loading time for game with mod" +
                            "\n     - Jinx should no longer be able to somehow jinx themself" +
                            "\n     - Cursed Wolf should no longer be able to somehow curse themself" +
                            "\n     - Fixed bug when extra title appears in settings mod" +
                            "\n     - Fixed bug when modded non-host can't guess add-ons and some roles" +
                            "\n     - Fixed bug when some roles could not get Add-ons" +
                            "\n     - Fixed a bug where the text \"Devoured\" did not appear for the player" +
                            "\n     - Fixed bug where non-Lovers players would dead together" +
                            "\n     - Fixed bug when shield in-lobby caused by Vulture cooldown up" +
                            "\n     - Fixed bug where role Tracefinder sometime did not have arrows" +
                            "\n     - Fixed bug when setting \"Neutrals Win Together\" doesn't work" +
                            "\n     - Fixed Bug When Some Neutrals Cant Click Sabotage Button (Host)" +
                            "\n     - Fixed Zoom" +
                            "\n     - Some fixes black screen" +
                            "\n     - Some Fix for Sheriff" +
                            "\n     - Fixed Tracker Arrow" +
                            "\n     - Fixed Divinator" +
                            "\n     - Fixed some add-on conflicts" +
                            "\n     - Fixed Report Button Icon\n\r" +

                        "\n\r<b>【Improvements Roles】</b>" +
                            "\n     - Fortune Teller" +
                            "\n     - Serial Killer" +
                            "\n     - Camouflager" +
                            "\n     - Retributionist Balancing" +
                            "\n     - Setting: Arsonist keeps the game going" +
                            "\n     - Vector setting: Vent Cooldown" +
                            "\n     - Jester setting: Impostor Vision" +
                            "\n     - Avenger setting: Crewmates/Neutrals can become Avenger" +
                            "\n     - Judge Can TrialIs Coven" +
                            "\n     - Setting: Torch is affected by Lights Sabotage" +
                            "\n     - SS Duration and CD setting for Miner and Escapist" +
                            "\n     - Added ability use limit for Time Master and Grenadier" +
                            "\n     - Added the ability to increase abilities when completing tasks for: Coroner, Chameleon, Tracker, Mechanic, Oracle, Inspector, Medium, Fortune Teller, Grenadier, Veteran, Time Master, and Pacifist" +
                            "\n     - Setting to hide the shot limit for Sheriff" +
                            "\n     - Setting for Fortune Teller whether it shows specific roles instead of clues on task completion" +
                            "\n     - Settings for Tracefinder that determine a delay in when the arrows show up" +
                            "\n     - Setting for Mortician whether it has arrows toward bodies or not" +
                            "\n     - Setting for Oracle that determines the chance of showing an incorrect result" +
                            "\n     - Settings for Mechanic that determine how many uses it takes to fix Reactor/O2 and Lights/Comms" +
                            "\n     - Setting for Swooper, Wraith, Chameleon, and Shade that determines if the player can vent normally when invisibility is on cooldown" +
                            "\n     - Chameleon uses the engineer vent cooldown" +
                            "\n     - Vampire and Poisoner now have their cooldowns reset when the bitten/poisoned player dies\n\r" +

                        "\n\r<b>【New Client Settings】</b>" +
                            "\n     - Show FPS" +
                            "\n     - Game Master (GM) (has been moved)" +
                            "\n     - Text Overlay" +
                            "\n     - Small Screen Mode" +
                            "\n     - Old Role Summary\n\r" +

                        "\n\r<b>【New Mod Settings】</b>" +
                            "\n     - Use Protection Anti Blackout" +
                            "\n     - Killer count command (Also includes /kcount command)" +
                            "\n     - See ejected roles in meetings" +
                            "\n     - Remove pets at dead players (Vanilla bug fix)" +
                            "\n     - Setting to disable unnecessary shield animations" +
                            "\n     - Setting to hide the kill animation when guesses happen" +
                            "\n     - Disable comms camouflage on some maps" +
                            "\n     - Block Switches When They Are Up" +
                            "\n     - Sabotage Cooldown Control" +
                            "\n     - Reset Doors After Meeting (Airship/Polus)\n\r" +

                        "\n\r<b>【Some Changes】</b>" +
                            "\n     - Victory and Defeat text is no longer role colored" +
                            "\n     - Last Impostor can no longer be guessed" +
                            "\n     - Tasks from a crewmate lover now count towards a task win" +
                            "\n     - Infected players now die after a meeting if there's no alive Infectious" +
                            "\n     - Body reports during camouflage is now separated" +
                            "\n     - Vector, Egoist, Revolutionist, Provocateur, Guesser are no longer experimental" +
                            "\n     - Added ability to change settings by 5 instead of 1 when holding the Left/Right Shift key" +
                            "\n     - All ability cooldowns are now reset after meetings" +
                            "\n     - Lovers сan not become Sunnyboy" +
                            "\n     - Tasks bar always set to none" +
                            "\n     - \"/r\" command has been improved\n\r" +

                        "\n\r<b>【New Features】</b>" +
                            "\n     - Load time reduced significantly" +
                            "\n     - The mod has been translated to Spanish (Partially)" +
                            "\n     - The mod has been translated to Chinese" +
                            "\n     - Improvement Random Map" +
                            "\n     - Main menu has been changed" +
                            "\n     - Added new buttons in main menu" +
                            "\n     - Added Auto starting features" +
                            "\n     - Reworked Discord Rich Presence" +
                            "\n     - Moderator and Sponsor improvement (/kick, /ban, /warn, and Moderator tags)" +
                            "\n     - Default template file has been updated" +
                            "\n     - Reworked end game summary (In the settings you can also return the old)" +
                            "\n     - Improvement platform kick" +
                            "\n     - Check Supported Version Among Us",

                    Date = "2023-9-10T00:00:00Z"

                };
                AllModNews.Add(news);
            }

            {
                // TOHE v2.5.0
                var news = new ModNews
                {
                    Number = 80001,
				    Title = "TownOfHostEdited v2.5.0",
				    SubTitle = "★★★★又是一次大更新，也许更大？★★★★",
				    ShortTitle = "★TOHE v2.5.0",
                    Text = "<size=150%>欢迎来到 TOHE v2.5.0.</size>\n\n<size=125%>支持 Among Us v2023.7.11 和 v2023.7.12</size>\n"

                        + "\n【对应官方版本】\n - 基于官方版本 v4.1.2\r\n"
                        + "\n【修正】\n - 各种错误的修复\n\r"
                        + "\n【更改】\n - 妖术图标更改为与巫师分开\n - 由于计划和未完成的工作，占卜师搬到了实验性身份里\n\r"

                        + "\n【身份新增】\n - 新内鬼身份: 龙卷风 \n\r - 新船员身份: 变色龙 \n\r - 新内鬼身份: 化形者\n\r - 新船员身份: 检查员 \n\r - 新中立身份: 美杜莎\n\r - 新附加职业: 懒人\n\r - 新附加职业: 墓碑\n\r - 新附加职业: 尸检 (来自 TOHY)\n\r - 新附加职业: 忠诚 \n\r - 新附加职业: 窥探者 \n\r- 新的实验性身份: 灵魂召唤者 \n\r"

                        + "\n【身份更改】\n - 进行了各种更改，例如更新了投机者\n\r",

				    Date = "2023-7-14T00:00:00Z",

                };
                AllModNews.Add(news);
            }

            {
                // TOHE v2.4.2
                var news = new ModNews
                {
                    Number = 80000,
				    Title = "TownOfHostEdited v2.4.2",
				    SubTitle = "★★★★哦，更大的更新★★★★",
				    ShortTitle = "★TOHE v2.4.2",
                    Text = "添加了一些新内容，以及一些错误修复.\r\nAmong Us v2023.3.28 是推荐的，以便身份正常游玩\n"

                        + "\n【对应官方版本】\n - 基于官方版本 v4.1.2\r\n"
                        + "\n【修正】\n - 修复了各种黑屏错误 (有些仍然存在，但应该不那么常见)\r\n - 其他各种错误修复 (他们很难追踪)\n\r"
                        + "\n【更改】\n - 法官现在支持猜测模式\r\n - 背景图像恢复为使用 AU v2023.3.28 的大小，由于推荐 Among Us 版本为 v2023.3.28\r\n - 许多其他未列出的变化\r\n - 出于版权考虑，马里奥更名为Vector\r\n"

                        + "\n【身份新增】\n - ###内鬼 \n - 议员 \r\n - 死亡契约 \r\n - 破坏者 (更换抑郁者的概率为25%) \r\n - 军师 \r\n - 眩晕者 \r\n - 吞噬者 \r\n\n ### 船员 \n - 瘾君子 \r\n - 寻迹者 \r\n - 捕快 \r\n - 商人 \r\n - 神谕 \r\n - 灵魂论者 \r\n - 惩罚者 \r\n- 守护者 \r\n - 君主 \r\n\n ### 中立 \n - 独行者 \r\n - 被诅咒的灵魂 \r\n - 秃鹫 \r\n - 扫把星 \r\n - 小偷 \r\n - 祭祀者 \r\n - 背叛者 \r\n\n ### 附加职业 \n - 双重猜测 \r\n - 流氓 \r\n"

                        + "\n【身份更改】\n - 宝箱怪现在有了一个可以看到死去玩家的身份设置，因为这个附加职业是多么的无用 \r\n - 一个暴露的工作狂再也不怕被赌死了 \r\n - 医生有一个像工作狂这样的设置将向所有人展示(目前暴露邪恶的医生，使用风险自负) \r\n - 市长有一个TOS机械师展示自己的场景 \r\n - 巫师平衡 \r\n - 清理工平衡 (将击杀冷却时间重置为清洁工设置中设置的值) \r\n - 更新君主 \r\n- 删除了增速者的速度提升 \r\n"
                        + "\n【删除】\n - 删除了闪电侠 \r\n - 删除了增速者 \r\n - 暂时被移走了，被遗忘了 ",

				    Date = "2023-7-5T00:00:00Z"

                };
                AllModNews.Add(news);
            }
        }
    }

    [HarmonyPatch(typeof(PlayerAnnouncementData), nameof(PlayerAnnouncementData.SetAnnouncements)), HarmonyPrefix]
    public static bool SetModAnnouncements(PlayerAnnouncementData __instance, [HarmonyArgument(0)] ref Il2CppReferenceArray<Announcement> aRange)
    {
        if (!AllModNews.Any())
        {
            Init();
            AllModNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });
        }

        List<Announcement> FinalAllNews = new();
        AllModNews.Do(n => FinalAllNews.Add(n.ToAnnouncement()));
        foreach (var news in aRange)
        {
            if (!AllModNews.Any(x => x.Number == news.Number))
                FinalAllNews.Add(news);
        }
        FinalAllNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });

        aRange = new(FinalAllNews.Count);
        for (int i = 0; i < FinalAllNews.Count; i++)
            aRange[i] = FinalAllNews[i];

        return true;
    }
}