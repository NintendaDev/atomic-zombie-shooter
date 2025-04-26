#if UNITY_EDITOR
namespace Atomic.Contexts
{
    internal static class ContextAPITemplate
    {
        internal const string Value =
            "header: ContextAPI\n" +
            "contextType: IContext\n" +
            "aggressiveInlining: true\n" +
            "\n" +
            "namespace: SampleGame\n" +
            "className: SampleContextAPI\n" +
            "directory: Assets/Scripts/Codegen\n " +
            "\n" +
            "imports:\n" +
            "- UnityEngine\n" +
            "- Atomic.Contexts\n" +
            "\n" +
            "values:\n" +
            "- Health: int\n" +
            "- Speed: float\n" +
            "- Transform: Transform\n";
    }
}
#endif