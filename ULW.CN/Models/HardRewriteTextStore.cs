namespace ULW.CN.Models;

internal class HardRewriteTextStore
{
    internal String AddDevicesSet => _addDevicesSet[AddDevicesSetRandNumber];
    internal String CommandWork => _addDevicesSet[CommandWorkRandNumber];
    internal String ConfiguredScheme => _addDevicesSet[ConfiguredSchemeRandNumber];
    internal String ConnectedDevices => _addDevicesSet[ConnectedDevicesRandNumber];
    internal String Ping1PC => _addDevicesSet[PingPCRandNumber];
    internal String Ping2PC => _addDevicesSet[PingPCRandNumber];
    internal String Ping3PC => _addDevicesSet[PingPCRandNumber];
    internal String Ping4PC => _addDevicesSet[PingPCRandNumber];

    internal HardRewriteTextStore()
    {
        Random rand = new Random();
        
        AddDevicesSetRandNumber = rand.Next(_addDevicesSet.Count);
        CommandWorkRandNumber = rand.Next(_сommandWork.Count);
        ConfiguredSchemeRandNumber = rand.Next(_configuredScheme.Count);
        ConnectedDevicesRandNumber = rand.Next(_connectedDevices.Count);
        PingPCRandNumber = rand.Next(_ping1PC.Count);
    }
    
    private int AddDevicesSetRandNumber;
    private readonly List<string> _addDevicesSet = new()
    {
        "Додавання пристроїв на схему",
        "Додані на схему пристрої",
        "Вигляд схеми з доданими пристроями"
    };
    
    private int CommandWorkRandNumber;
    private readonly List<string> _сommandWork = new()
    {
        "Результат виконання команди",
        "Дані, отримані командою",
        "Команда"
    };
    
    private int ConfiguredSchemeRandNumber;
    private readonly List<string> _configuredScheme = new()
    {
        "Вигляд готової схеми",
        "Налаштована схема",
        "Вигляд налаштованої схеми",
        "Готова схема",
    };
    
    private int ConnectedDevicesRandNumber;
    private readonly List<string> _connectedDevices = new()
    {
        "Вигляд з'єднаної схеми",
        "Схема, після з'єднання компонентів",
        "Схема, після з'єднання пристроїв",
        "Вигляд схеми зі з'єднаними пристроями"
    };
    
    private int PingPCRandNumber;
    private readonly List<string> _ping1PC = new()
    {
        "Пінгування на першому ПК",
        "Результат пінгування",
        "Результат пінгування на ПК 1"
    };
    private readonly List<string> _ping2PC = new()
    {
        "Пінгування на другому ПК",
        "Результат пінгування",
        "Результат пінгування на ПК 2"
    };
    private readonly List<string> _ping3PC = new()
    {
        "Пінгування на третьому ПК",
        "Результат пінгування",
        "Результат пінгування на ПК 3"
    };
    private readonly List<string> _ping4PC = new()
    {
        "Пінгування на четвертому ПК",
        "Результат пінгування",
        "Результат пінгування на ПК 4",
    };
}