using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace OpenBaseNetSqlServerCLI.Commands;

public class InstallCommand : AsyncCommand<EmptySettings>
{
    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] EmptySettings settings, CancellationToken cancellationToken)
    {
        await AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .StartAsync("Instalando template OpenBaseNET do NuGet.org...", async ctx =>
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    // Instala a última versão do seu template
                    Arguments = "new install w3ti.OpenBaseNET.SQLServer.Template",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                if (process != null)
                {
                    await process.WaitForExitAsync(cancellationToken);
                }
            });

        AnsiConsole.MarkupLine("[bold green]✔[/] Template instalado com sucesso!");
        AnsiConsole.MarkupLine("[grey]Agora você pode usar:[/] [blue]openbase new NomeDoProjeto[/]");
        return 0;
    }
}