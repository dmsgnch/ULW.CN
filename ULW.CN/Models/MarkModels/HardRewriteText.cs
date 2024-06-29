namespace ULW.CN.Models.MarkModels;

internal class HardRewriteText
{
    private HardRewriteTextStore _textStore;

    internal HardRewriteText()
    {
        _textStore = new();
    }
    
    internal string GetTextByMarkText(string markName)
    {
        switch (markName)
        {
            //Надпись под картинкой с только что добавленными устройствами на схему
            case "AddDevices": return _textStore.AddDevicesSet;
            
            //Надпись под картинкой с выполненой командой, после теста идет название комманд
            case "CommandWork": return _textStore.CommandWork;
            
            //Надпись под картинкой, которая отображает полностью настроенную схему
            case "ConfiguredScheme": return _textStore.ConfiguredScheme;
            
            //Надпись под картинкой схемы из соединнеными устройствами
            case "ConnectedDevices": return _textStore.ConnectedDevices;
            
            //Надпись под картинкой с пингом первого ПК
            case "Ping1PC": return _textStore.Ping1PC;
            
            //Надпись под картинкой с пингом второго ПК
            case "Ping2PC": return _textStore.Ping2PC;
            
            //Надпись под картинкой с пингом третьего ПК
            case "Ping3PC": return _textStore.Ping3PC;
            
            //Надпись под картинкой с пингом четвертого ПК
            case "Ping4PC": return _textStore.Ping4PC;
            
            default: throw new Exception($"Oops there are no any mark that have name: \"{markName}\"");
        }
    }
}