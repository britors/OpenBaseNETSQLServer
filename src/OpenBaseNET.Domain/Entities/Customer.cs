/*
 * Name: Customer
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Classe para representar entidade Cliente do banco de dados
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação da Classe                           |
 * |--------------------------------------------------------------|
 */

using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.ValueObjects;

namespace OpenBaseNET.Domain.Entities;

public sealed class Customer : IEntityOrQueryResult
{
    public int Id { get; init; }
    public Name Name { init; get; } = null!;
}