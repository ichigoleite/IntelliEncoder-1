namespace IntelliEncoder1.Schema.TWC;

abstract public class DataRecord
{
    // This is to define a record that will be added onto the payload.

    // This function executes GenerateInternal and sends the output of that.
    public Task<string> Generate()
    {
        return GenerateInternal();
    }

    // This generates the part of the DataRecord that is appended on to the payload.
    protected abstract Task<string> GenerateInternal();
}