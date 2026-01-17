using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace OpenBaseNetSqlServerCLI.Commands;

public class NewSettings : CommandSettings
{
    [CommandArgument(0, "<PROJECT_NAME>")]
    [Description("O nome do projeto que será criado")]
    public string ProjectName { get; set; } = string.Empty;

    [CommandOption("-o|--output")]
    [Description("Diretório de saída (opcional)")]
    public string? OutputPath { get; set; }
}

public class NewCommand : AsyncCommand<NewSettings>
{
    // A assinatura precisa ter os 3 parâmetros: context, settings e cancellationToken
    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] NewSettings settings, CancellationToken cancellationToken)
    {
        AnsiConsole.Write(new FigletText("OpenBaseNET").Color(Color.Blue));
        
        await AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .StartAsync("Executando template NuGet...", async ctx =>
            {
                var arguments = $"new openbasenet-sql -n {settings.ProjectName}";
                
                if (!string.IsNullOrEmpty(settings.OutputPath))
                {
                    arguments += $" -o {settings.OutputPath}";
                }

                var processInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                
                if (process == null)
                    throw new Exception("Falha ao iniciar o processo 'dotnet'.");

                // Passamos o token para o WaitForExitAsync para respeitar cancelamentos (Ctrl+C)
                await process.WaitForExitAsync(cancellationToken);

                if (process.ExitCode != 0)
                {
                    var error = await process.StandardError.ReadToEndAsync(cancellationToken);
                    AnsiConsole.MarkupLine($"[red]Erro:[/] {error}");
                }
            });

        AnsiConsole.MarkupLine($"[bold green]✔[/] Projeto [bold blue]{settings.ProjectName}[/] gerado com sucesso!");
        return 0;
    }
}