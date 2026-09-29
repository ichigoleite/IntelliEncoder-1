namespace IntelliEncoder1.Schema.TWC;

abstract public class DataRecord
{
    // This is to define a record that will be added onto the payload.

    // This generates the part of the DataRecord that is appended on to the payload.
    protected abstract async Task<string> Generate();
}