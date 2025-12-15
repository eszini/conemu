using System.Collections.Generic;

namespace adm_conemu
{
    public class RootConfig
    {
        public ProjectConfig Project { get; set; } = new ProjectConfig();
        public List<TerminalConfig> Terminals { get; set; } = new List<TerminalConfig>();
    }

    public class ProjectConfig
    {
        public string Name { get; set; } = "";
        public string Root { get; set; } = "";
        public string TaskName { get; set; } = "";
        public string ShortcutName { get; set; } = "";
        public string ConEmuPath { get; set; } = "";
        public string TaskDirParam { get; set; } = "";
    }

    public class TerminalConfig
    {
        public string SubDir { get; set; } = ".";
        public string Title { get; set; } = "";
        public string EnvBat { get; set; } = "";
    }
}

