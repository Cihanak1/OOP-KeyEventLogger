namespace KeyEventLogger;

public class KeyEventRecord
{
    public string EventType { get; set; }
    public string KeyName { get; set; }
    public DateTime EventTime { get; set; }

    public KeyEventRecord(string eventType, string keyName, DateTime eventTime)
    {
        EventType = eventType;
        KeyName = keyName;
        EventTime = eventTime;
    }

    public override string ToString()
    {
        return $"[{EventTime:HH:mm:ss.fff}] Olay: {EventType} | Tuş: {KeyName}";
    }
}
