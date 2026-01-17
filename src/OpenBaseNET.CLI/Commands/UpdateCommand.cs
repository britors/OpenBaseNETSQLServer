using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace OpenBaseNetSqlServerCLI.Commands;

public class UpdateCommand : AsyncCommand<EmptySettings>
{
    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] EmptySettings settings, CancellationToken cancellationToken)
    {
        await AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .StartAsync("Buscando atualizações no NuGet...", async ctx =>
            {
                // 1. Atualiza o Template
                ctx.Status("Atualizando Template OpenBaseNET...");
                await RunDotnetCommand("new update", cancellationToken);
                AnsiConsole.MarkupLine("[blue]v[/] Verificação de templates concluída.");

                // 2. Atualiza a própria CLI
                ctx.Status("Atualizando OpenBase CLI...");
                await RunDotnetCommand("tool update -g w3ti.OpenBaseNETSqlServer.Cli", cancellationToken);
                AnsiConsole.MarkupLine("[blue]v[/] Verificação da CLI concluída.");
            });

        AnsiConsole.MarkupLine("[bold green]✔[/] Processo de atualização finalizado!");
        return 0;
    }

    private static async Task RunDotnetCommand(string args, CancellationToken ct)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = args,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(processInfo);
        if (process != null)
        {
            await process.WaitForExitAsync(ct);
        }
    }
}

// Classe auxiliar para comandos que não recebem argumentos
public class EmptySettings : CommandSettings { }