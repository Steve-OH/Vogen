using System.Text.Json;
using System.Text.Json.Serialization;
using Vogen;

namespace UsingTypesGeneratedInTheSameProject;

/*
 * In this scenario, we want to use the System.Text.Json converters
 * for the value objects that were generated by Vogen in this project.
 *
 * We create a `Supplier` which contains value objects, we serialize it to a string,
 * and we deserialize back into an Order.
 *
 * We use the `SupplierGenerationContext` below and tell it about `Supplier`. It then goes through its properties
 * and builds a mapping of converters.
 *
 * **NOTE** - because the value objects WERE BUILT IN THIS PROJECT, they are not 'fully formed', so we need to
 * tell System.Text.Json to use the 'type factory' that Vogen generates (Infra.VogenTypesFactory) to get its hints about
 * mapping types to converters.
 */


public static class SystemTextJsonSourceGenerationScenario_UsingTypesGeneratedInTheSameProject
{
    public static void Run()
    {
        Supplier supplier = new(SupplierId.From(123), SupplierName.From("Freshco"), LastInvoiceAmount.From(42.69m));
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new Infra.VogenTypesFactory()
            }
        };

        var ctx = new SupplierGenerationContext(options);
            
        var json = JsonSerializer.Serialize(supplier, ctx.Supplier);

        Supplier supplier2 = JsonSerializer.Deserialize(json, ctx.Supplier)!;

        Console.WriteLine(json);
        Console.WriteLine(supplier2.SupplierId);
        Console.WriteLine(supplier2.SupplierName);
        Console.WriteLine(supplier2.LastInvoiceAmount);

    }
}

public record Supplier(SupplierId SupplierId, SupplierName SupplierName, LastInvoiceAmount LastInvoiceAmount);
                                                 
[ValueObject]
public readonly partial struct SupplierId;

[ValueObject<string>]
public readonly partial struct SupplierName;

[ValueObject<decimal>]
public readonly partial struct LastInvoiceAmount;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Supplier))]
[JsonSerializable(typeof(decimal))]
[JsonSerializable(typeof(int))]
internal partial class SupplierGenerationContext  : JsonSerializerContext;
