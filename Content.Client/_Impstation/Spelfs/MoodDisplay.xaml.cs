using System.Linq;
using Content.Client.Chat.Managers;
using Content.Client.Message;
using Content.Shared._Impstation.Spelfs;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Client._Impstation.Spelfs;

[GenerateTypedNameReferences]
public sealed partial class MoodDisplay : Control
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
    [Dependency] private readonly IChatManager _chatManager = default!;
    [Dependency] private readonly EntityManager _entityManager = default!;

    private string GetSharedString()
    {
        return $"[italic][font size=10][color=gray]{Loc.GetString("moods-ui-shared-mood")}[/color][/font][/italic]";
    }

    public MoodDisplay(SpelfMood mood, bool shared)
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        if (shared)
            MoodNameLabel.SetMarkup($"{mood.GetLocName()} {GetSharedString()}");
        else
            MoodNameLabel.SetMarkup(mood.GetLocName());
        MoodDescLabel.SetMarkup(mood.GetLocDesc());
    }
}
